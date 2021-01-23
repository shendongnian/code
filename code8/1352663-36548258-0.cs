		public abstract class BaseViewModel : INotifyPropertyChanged 
		{
			private ICommand _f1KeyCommand;
			public ICommand F1KeyCommand
			{
				get
				{
					if (_f1KeyCommand == null)
						_f1KeyCommand = new DelegateCommand(F1KeyCommandCallback, CanExecute);
					return _f1KeyCommand;
				}
			}
			/// <summary>
			/// Fired if F1 is pressend and 'CanExecute' returns true
			/// </summary>
			private void F1KeyCommandCallback(object obj)
			{
				Console.WriteLine("F1KeyCommandCallback fired");
			}
			
			// ....
		}
	
