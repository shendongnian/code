    public static void updateValues()
    {
        srGlobalStatics[0] = "changed";
    }
    public static ObservableCollection<string> srGlobalStatics = 
       new ObservableCollection<string> { "test" };
