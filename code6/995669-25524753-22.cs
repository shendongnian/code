	class ViewModelLocator
	{
		public UserControlViewModel UserControlViewModel
		{
			get { return IocKernel.Get<UserControlViewModel>();} // Loading UserControlViewModel will automatically load the binding for IStorage
		}
	}
