<!-- -->
	public class CommitGroupCommand : ICommand
	{
		public BindingGroup BindingGroup { get; set; }
		public event EventHandler CanExecuteChanged;
		public bool CanExecute(object parameter)
		{
			return true;
		}
		public void Execute(object parameter)
		{
			BindingGroup.UpdateSources();
		}
	}
