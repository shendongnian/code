	public static class ModalManager
	{
		public static bool TryRespondModal<TData>(this IModalResponse<TData> source, TData data, bool autoPop = true, bool animate = false)
		{
			if (Application.Current.MainPage.Navigation.ModalStack.Count <= 0)
				return false;
			source.ModalRequestComplete.SetResult(data);
			if (autoPop)
				Application.Current.MainPage.Navigation.PopModalAsync(animate);
			return true;
		}
		public static Task<TData> GetResponseAsync<TData>(this IModalResponse<TData> source)
		{
			source.ModalRequestComplete = new TaskCompletionSource<TData>();
			return source.ModalRequestComplete.Task;
		}
	}
	public enum WizardState
	{
		Indeterminate = 0,
		Complete = 1,
		Canceled = 2
	}
	public class WizardModel
	{
		public WizardState State { get; set; }
		public List<string> Page1Values { get; set; } = new List<string>();
		public List<string> Page2Values { get; set; } = new List<string>();
		public List<string> Page3Values { get; set; } = new List<string>();
	}
	public abstract class WizardPage : IModalResponse<WizardModel>
	{
		public WizardModel Model { get; set; }
		public ICommand NextCommand { get; set; }
		public ICommand PreviousCommand { get; set; }
		public ICommand CancelCommand { get; set; }
		protected WizardPage(WizardModel model)
		{
			Model = model;
			NextCommand = new Command(NextButtonPressed);
			PreviousCommand = new Command(PreviousButtonPressed);
			CancelCommand = new Command(PreviousButtonPressed);
		}
		protected abstract IModalResponse<WizardModel> GetNextPage();
		protected virtual void CancelButtonPressed()
		{
			Model.State = WizardState.Canceled;
			this.TryRespondModal(Model);
		}
		protected virtual void PreviousButtonPressed()
		{
			// you're dropping down on the level of dependent windows here so you can tell your previous modal window the result of the current response
			this.TryRespondModal(Model);
		}
		protected virtual async void NextButtonPressed()
		{
			var np = GetNextPage();
			if (Model.State == WizardState.Complete || np == null || (await np?.GetResponseAsync()).State == WizardState.Complete)
				PersistWizardPage();
			// all following modal windows must have run through - so you persist whatever your page has done, unless you do that on the last page anyway. and then tell the previous
			// modal window that you're done
			this.TryRespondModal(Model);
		}
		protected virtual void PersistWizardPage()
		{
			// virtual because i'm lazy
			throw new NotImplementedException();
		}
		public TaskCompletionSource<WizardModel> ModalRequestComplete { get; set; }
	}
	public class Page1 : WizardPage
	{
		public Page1(WizardModel model) : base(model)
		{
		}
		protected override IModalResponse<WizardModel> GetNextPage()
		{
			return new Page2(Model);
		}
	}
	public class Page2 : WizardPage
	{
		public Page2(WizardModel model) : base(model)
		{
		}
		protected override IModalResponse<WizardModel> GetNextPage()
		{
			return new Page3(Model);
		}
	}
	public class Page3 : WizardPage
	{
		public Page3(WizardModel model) : base(model)
		{
		}
		protected override IModalResponse<WizardModel> GetNextPage()
		{
			return null;
		}
		protected override void NextButtonPressed()
		{
			this.Model.State = WizardState.Complete;
			base.NextButtonPressed();
		}
	}
	public interface IModalResponse<TResponseType>
	{
		TaskCompletionSource<TResponseType> ModalRequestComplete { get; set; }
	}
