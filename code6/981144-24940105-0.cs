    class PivotCallbacks
    {
         public Action Initiate { get; set; }
         public Action OnAvtivated { get; set; }
         public Action<CancelEventArgs> OnBackKeyPress { get; set; }
    }
