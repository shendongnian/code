    public class ViewModelPropertyChange
	{
		private readonly ViewModelBase _viewModel;
		public ViewModelPropertyChange(ViewModelBase viewModel)
		{
			_viewModel = viewModel;
		}
		public ViewModelPropertyChange WithDependent(string name)
		{
			_viewModel.OnPropertyChanged(name);
			return this;
		}
	}
