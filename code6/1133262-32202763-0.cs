    public HomeViewController (IntPtr handle) : base (handle)
    {
      LoadValues();
    }
    async Task LoadValues()
    {
      var pc = new PersonCollection ();
      var jsonObject=await pc.StoreData ();
      InvokeOnMainThread(()=>{
       textFieldInstance.Text= jsonObject.Name;
      });
     }
