	using System;
	using System.Windows;
	using System.Windows.Input;
	namespace RelayCommandDemo
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				DataContext = new VM();
			}
		}
		public class VM
		{
			public String Name { get; set; }
			private ICommand _SaveCommand;
			public ICommand SaveCommand
			{
				get { return _SaveCommand; }
			}
			public VM()
			{
				_SaveCommand = new RelayCommand(SaveCommand_Execute, SaveCommand_CanExecute);
			}
			public void SaveCommand_Execute()
			{
				MessageBox.Show("Save Called");
			}
			public bool SaveCommand_CanExecute()
			{
				if (string.IsNullOrEmpty(Name))
					return false;
				else
					return true;
			}
		}
		public class RelayCommand : ICommand
		{
			public event EventHandler CanExecuteChanged
			{
				add { CommandManager.RequerySuggested += value; }
				remove { CommandManager.RequerySuggested -= value; }
			}
			private Action methodToExecute;
			private Func<bool> canExecuteEvaluator;
			public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
			{
				this.methodToExecute = methodToExecute;
				this.canExecuteEvaluator = canExecuteEvaluator;
			}
			public RelayCommand(Action methodToExecute)
				: this(methodToExecute, null)
			{
			}
			public bool CanExecute(object parameter)
			{
				if (this.canExecuteEvaluator == null)
				{
					return true;
				}
				else
				{
					bool result = this.canExecuteEvaluator.Invoke();
					return result;
				}
			}
			public void Execute(object parameter)
			{
				this.methodToExecute.Invoke();
			}
		}
	}
