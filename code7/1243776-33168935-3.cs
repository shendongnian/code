    		public Page ResolveView<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel
		{
			TViewModel viewModel;
			var view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
			return view;
		}
		public Page ResolveView<TViewModel>(TViewModel viewModel)
			where TViewModel : class, IViewModel
		{
			var view = _viewFactory.Resolve(viewModel);
			return view;
		}
