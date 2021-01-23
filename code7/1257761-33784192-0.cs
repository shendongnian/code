	namespace GalaSoft.MvvmLight.Command
	{
		/// <omitted, see below>
		public class RelayCommand<T> : ICommand
		{
			private readonly WeakAction<T> _execute;
			private readonly WeakFunc<T, bool> _canExecute;
			/// <summary>
			/// Occurs when changes occur that affect whether the command should execute.
			/// 
			/// </summary>
			public event EventHandler CanExecuteChanged;
