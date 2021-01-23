    public HomeViewController (IntPtr handle) : base (handle)
    {
      Setup();
    }
    async void Setup()
    {
       var pc = new PersonCollection ();
       await pc.StoreData ();
       // Set The text of the label here
       
    }
