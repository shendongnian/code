    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    
    namespace Common
    {
        public class Command<TArgs> : ICommand
        {
            public Command(Action<TArgs> exDelegate)
            {
                _exDelegate = exDelegate;
            }
    
            public Command(Action<TArgs> exDelegate, Func<TArgs, bool> canDelegate)
            {
                _exDelegate = exDelegate;
                _canDelegate = canDelegate;
            }
    
            protected Action<TArgs> _exDelegate;
            protected Func<TArgs, bool> _canDelegate;
    
            #region ICommand Members
    
            public bool CanExecute(TArgs parameter)
            {
                if (_canDelegate == null)
                    return true;
    
                return _canDelegate(parameter);
            }
    
            public void Execute(TArgs parameter)
            {
                if (_exDelegate != null)
                {
                    _exDelegate(parameter);
                }
            }
    
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
    
            bool ICommand.CanExecute(object parameter)
            {
                if (parameter != null)
                {
                    var parameterType = parameter.GetType();
                    if (parameterType.FullName.Equals("MS.Internal.NamedObject"))
                        return false;
                }
    
                return CanExecute((TArgs)parameter);
            }
    
            void ICommand.Execute(object parameter)
            {
                Execute((TArgs)parameter);
            }
    
            #endregion
        }
    }
