    static void Main(string[] args)
    {
        //Assuming you added a string setting named "FooSetting" you can set it like this:
    	Properties.Settings.Default.FooSetting = "Some Value...";
    	Properties.Settings.Default.Save(); //you must call save or it won't persist
        //Read a value like this:
    	Console.WriteLine(Properties.Settings.Default.FooSetting);
    	Console.ReadKey();
    }
