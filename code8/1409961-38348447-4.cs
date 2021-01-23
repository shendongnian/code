    using System;
    using System.Windows.Input;
    
        public class DelegateCommand : ICommand
        {
            private readonly Action<object> m_command;
    
            private readonly Predicate<object> m_canExecute;
    
            public DelegateCommand(Action<object> command, Predicate<object> canExecute = null)
            {
                if (command == null)
                {
                    throw new ArgumentNullException("command", "The delegate command is null");
                }
    
                m_canExecute = canExecute;
                m_command = command;
            }
    
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
    
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
    
            public void Execute(object parameter)
            {
                m_command(parameter);
            }
    
            public bool CanExecute(object parameter)
            {
                return m_canExecute == null || m_canExecute(parameter);
            }
        }
