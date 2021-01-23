    public class MyViewModel
    {
        private MyObject _currentObject;
        public MyObject CurrentObject
        {
            get { return this._currentObject; }
            set
            {
                this._currentObject = value;
                //Usually where OnPropertyChanged goes or however you implement INotifyPropertyChanged
                
                //Where we call our command, logic can be introduced if needed.
                //Also we may just call the method directly.
                this.SomeCommand.Execute(null);
            }
        }
        private Command _someCommand;
        public Command SomeCommand
        {
            get
            {
                return this._someCommand ?? (this._someCommand = new Command(
                    () =>
                    {
                        this.SomeMethod();
                    },
                    () =>
                    {
                        //The CanExecute test, returns bool.
                        return this._currentObject != null ? true : false;
                    }));
            }
        }
        private string SomeMethod()
        {
            return "I just got called yo!";
        }
    }
 
