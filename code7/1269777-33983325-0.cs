    using Caliburn.Micro;
     
    namespace CaliburnMicroExample
    {
        public class ShellViewModel : PropertyChangedBase
        {
            private string _message;
     
            public string Message
            {
                get { return _message; }
                set
                {
                    _message = value;
                    NotifyOfPropertyChange(() => Message);
                }
            }
     
            public ShellViewModel()
            {
                Message = "Hello World";
            }
        }
    }
