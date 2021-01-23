    public interface IUiService {
        void Close();
        void Show<TVm>(TVm vm) where TVm : ViewModel;
        public T ShowDialog<T, TVm>(TVm vm) 
			where T : class
			where TVm : ViewModel, IDialogReturnVm<T>;
    }
	public class UiService : IUiService
	{
		private readonly Window window;
		public UiService(Window window)
		{
			this.window = window;
		}
		public void Close()
		{
			this.window.Close();
		}
		public void Show<TVm>(TVm vm) where TVm : ViewModel
		{
			Type windowType = ViewLocator.GetViewType<TVm>()
			var wnd = (Window)Activator.CreateInstance(windowType);
			wnd.DataContext = vm;
			wnd.Owner = Application.Current.MainWindow;
			vm.Init(new UiService(wnd));
			wnd.Show();
		}
		public T ShowDialog<T, TVm>(TVm vm) 
			where T : class  //T is the type of imformation which the Vm will "return" when it's window is closed.
			where TVm : ViewModel, IDialogReturnVm<T>
		{
			Type windowType = ViewLocator.GetViewType<TVm>()
			var wnd = (Window)Activator.CreateInstance(windowType);
			wnd.DataContext = vm;
			wnd.Owner = Application.Current.MainWindow;
			vm.Init(new UiService(wnd));
			wnd.ShowDialog();
			return vm.ReturnInfo;
		}
	}
