    static void Main(string[] args)
    {
        SettingSerializer serializer = new SettingSerializer();
    
        Settings settings = serializer.Deserialize();
    
        Console.WriteLine(settings.Homepage);    
    
        Console.WriteLine(settings.DefaultAudioLevel);
    
        Console.ReadKey();
    }
