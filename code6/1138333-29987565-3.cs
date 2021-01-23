	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Input;
	namespace DockPanel
	{
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
		}
		public class VM
		{
			public bool IsFilenameCorrect { get; set; }
			public ICommand ButtonBeginReadCommand { get; set; }
			public ICommand ButtonBeginWriteCommand { get; set; }
			private object _locker = new object();
			public VM()
			{
				
				IsFilenameCorrect = true;
				ButtonBeginReadCommand = new AsyncCommand(async () =>
						{
							await Task.Delay(300);
							Monitor.Enter(_locker);
							MessageBox.Show("Read");
							Monitor.Exit(_locker);
						});
				ButtonBeginWriteCommand = new AsyncCommand(async () =>
				{
					await Task.Delay(300);
					Monitor.Enter(_locker);
					MessageBox.Show("Write");
					Monitor.Exit(_locker);
				});
			}
		}
		public interface IAsyncCommand : ICommand
		{
			Task ExecuteAsync(object parameter);
		}
		public abstract class AsyncCommandBase : IAsyncCommand
		{
			public abstract bool CanExecute(object parameter);
			public abstract Task ExecuteAsync(object parameter);
			public async void Execute(object parameter)
			{
				await ExecuteAsync(parameter);
			}
			public event EventHandler CanExecuteChanged
			{
				add { CommandManager.RequerySuggested += value; }
				remove { CommandManager.RequerySuggested -= value; }
			}
			protected void RaiseCanExecuteChanged()
			{
				CommandManager.InvalidateRequerySuggested();
			}
		}
		public class AsyncCommand : AsyncCommandBase
		{
			private readonly Func<Task> _command;
			public AsyncCommand(Func<Task> command)
			{
				_command = command;
			}
			public override bool CanExecute(object parameter)
			{
				return true;
			}
			public override Task ExecuteAsync(object parameter)
			{
				return _command();
			}
		}
	}
