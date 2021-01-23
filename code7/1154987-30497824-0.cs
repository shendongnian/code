        //Very basic ICommand implementation    
        public class RelayCommand : ICommand
        {
            private Action<object> command;
            private Func<bool> canExecute;
        
            public RelayCommand(Action<object> commandAction, Func<bool> canExecute = null)
            {
                this.command = commandAction;
                this.canExecute = canExecute;
            }
        
            /// <summary>
            /// Returns default true. 
            /// Customize to implement can execute logic.
            /// </summary>
            public bool CanExecute(object parameter)
            {
                return this.canExecute == null ? true : this.canExecute();
            }
        
            /// <summary>
            /// Implement changed logic if needed
            /// </summary>
            public event EventHandler CanExecuteChanged;
        
        
            public void Execute(object parameter)
            {            
                if (this.command != null)
                {
                    this.command(parameter);
                }
            }
        }
        
        //Example of a view model
        public class MyViewModel
        {
            public MyViewModel()
            {
                this.ExpanderCommand = new RelayCommand(this.ExecuteExpanderCommand);
            }
        
            // This property will be the command binding target
            public RelayCommand ExpanderCommand { get; set; }
        
            // this is the handler method
            public void ExecuteExpanderCommand(object parameter)
            {
                var section = (Sections)parameter;
                //do your stuff here
            }
        }
