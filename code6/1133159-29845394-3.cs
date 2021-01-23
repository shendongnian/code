	class ShellViewModel : PropertyChangedBase, IShell
	{
		private SomeViewModel _vm;
		public ShellViewModel(SomeViewModel vm)
		{
			_vm = vm;
		}
	}
