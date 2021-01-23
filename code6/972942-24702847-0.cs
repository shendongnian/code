	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Input;
    public class AsyncRelayCommand : ICommand {
        protected readonly Func<Task> _asyncExecute;
        protected readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public AsyncRelayCommand(Func<Task> execute)
            : this(execute, null) {
        }
        public AsyncRelayCommand(Func<Task> asyncExecute, Func<bool> canExecute) {
            _asyncExecute = asyncExecute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter) {
            if(_canExecute == null) {
                return true;
            }
            return _canExecute();
        }
        public async void Execute(object parameter) {
            await ExecuteAsync(parameter);
        }
        protected virtual async Task ExecuteAsync(object parameter) {
            await _asyncExecute();
        }
    }
