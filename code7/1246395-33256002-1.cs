    public static void Main()
    {
    	VerticalAlignment some  = VerticalAlignment.All;
    
    	BinaryFormatter bf = new BinaryFormatter();
    	using (var writer = File.Create("SomeText.bin"))
    	{
    		bf.Serialize(writer, some);
    	}
    }
