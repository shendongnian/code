    public App()
    {
        // The root page of your application
        MainPage = new Page1
        {
            BindingContext = new ItemContainer()
        };
    }
