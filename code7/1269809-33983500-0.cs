    using System;
    using System.Windows.Input;
    
    namespace MyCommands
    {
        /// <summary>
        /// Base class for all Commands.
        /// </summary>
        public abstract class CommandBase : ICommand
        {
            /// <summary>
            /// Defines the method that determines whether the command can execute in its current 
            /// state.
            /// </summary>
            /// <param name="parameter">Data used by the command.  If the command does not require data 
            /// to be passed, this object can be set to null.</param>
            /// <returns>
            /// true if this command can be executed; otherwise, false.
            /// </returns>
            public virtual bool CanExecute(object parameter) 
            {
                return true;
            }
    
            /// <summary>
            /// Defines the method to be called when the command is invoked.
            /// </summary>
            /// <param name="parameter">Data used by the command.  If the command does not require data 
            /// to be passed, this object can be set to null.</param>
            public virtual void Execute(object parameter) {}
    
            /// <summary>
            /// Occurs when changes occur that affect whether or not the command should execute.
            /// </summary>
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
    }
