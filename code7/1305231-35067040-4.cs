    public class ViewModel
        {
            ICommand _cmd = new CustomCommand();
            public ICommand FunctionToCall
            {
                get { return _cmd; }
                set { _cmd = value; }
            }
    
            public string Item1 { get; set; }
    
            public ViewModel() { Item1 = "1Header"; }
        }
