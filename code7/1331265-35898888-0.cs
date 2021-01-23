    public class ViewModelA
    {  
      public event action<bool> SomeEvent;
        //invoke event somewhere 
        SomeEvent.Invoke(/*some bool argument */)
    }
    public class ViewModelB
    {
        public bool IsUserCtlVisible { get; set; }
        public ViewModelB()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.SomeEvent += (arg) => { IsUserCtlVisible = arg; };
        }
    }
