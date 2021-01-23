	class ShellViewModel : Conductor<IScreen>.Collection.AllActive, IShell
	{
		private Func<SomeViewModel> _vmFactory;
		public ShellViewModel(Func<SomeViewModel> vmFactory)
		{
			_vmFactory = vmFactory;
		}
		public void Add()
		{
			var newVM = _vmFactory();
			ActivateItem(newVM);
		}
	}
