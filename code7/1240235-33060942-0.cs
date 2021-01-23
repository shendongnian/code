	internal abstract class TimerBarCommandBase : ICommand
	{
		public TimerBarCommandBase(MainViewModel viewModel)
		{
			_MainViewModel = viewModel;
		}
	
		protected MainViewModel _MainViewModel;
		public event EventHandler CanExecuteChanged;
	
		public bool CanExecute(object parameter) { return true; }
	
		public abstract void Execute(object parameter);
	}
	
	internal class AddTimerBarCommand : TimerBarCommandBase
	{
		public AddTimerBarCommand(MainViewModel viewModel) : base(viewModel) { }
		
		public override void Execute(object parameter)
		{
			_MainViewModel.AddTimerBar();
		}
	}
	
	internal class RmvTimerBarCommand : TimerBarCommandBase
	{
		public RmvTimerBarCommand(MainViewModel viewModel) : base(viewModel) { }
		
		public override void Execute(object parameter)
		{
			_MainViewModel.RmvTimerBar();
		}
	}
