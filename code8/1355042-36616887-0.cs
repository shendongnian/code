    public static class MyDataCache 
	{
		public static MyData MyData { get; } = new MyData();
	}
	
	// in your pages
	protected override void OnAppearing()
    {            
        base.OnAppearing();
        // set data from MyDataCache.MyData
        MyProperty = MyDataCache.MyData.MyProperty;
    }
    protected override void OnDisappearing()
    {            
        base.OnDisappearing();
        // set data to MyDataCache.MyData
        MyDataCache.MyData.MyProperty = MyProperty;
    }
