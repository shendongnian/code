    public class BaseViewModel :ViewModelBase
    {
        public string Message {get; set;}
        public BaseViewModel()
        {
            Message = "Message from BaseViewModel View Model";
        }
    }
