    //In your callee code
    using (var stream = new FileStream(path, FileMode.Open))
    {
    	ConfigureStream(steam);
    	//Other stuff..
    }
    
    public static void ConfigureStream(Stream stream)
    {
    	stream.Seek(44, SeekOrigin.Current);
    }
