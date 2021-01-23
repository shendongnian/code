    class MyUserState
    {
        public double Value {get;set;}
        public string Content {get;set;}
    }
    worker.ReportProgress(55,new MyUserState { Value = 23.7, Content = "Working ..."});
    MyUserState state = e.UserState as MyUserState;
    progressbar.Value = state.Value;
    lblpercent.Content = state.Content;
