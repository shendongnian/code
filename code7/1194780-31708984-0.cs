    void Main()
    {
    	List<Alarm> listYouSerializeInto = new List<Alarm>();
    	listYouSerializeInto.Add(new Alarm("test", 2015, 07, 29, 06, 00));
    	listYouSerializeInto.Add(new Alarm("test", 2015, 07, 29, 07, 00));
    	listYouSerializeInto.Add(new Alarm("test", 2015, 07, 29, 08, 00));
    	
    	var serializer = new BinaryFormatter();
    	
    	using (FileStream stream = new FileStream(@"C:\Temp\alarm.bin", FileMode.Create))
    	{
    		serializer.Serialize(stream, listYouSerializeInto);
    	}
    
    	List<Alarm> listYouDeserializeInto = new List<Alarm>();	
    	using (Stream stream = new FileStream(@"C:\Temp\alarm.bin", FileMode.Open))
    	{
    
    		listYouDeserializeInto = (List<Alarm>)serializer.Deserialize(stream);
    		foreach (Alarm a in listYouDeserializeInto)
    		{
    			Console.WriteLine(a);
    		}
    
    
    	}
    	
    
    	
    }
    
    // Define other methods and classes here
    [Serializable]
    public class Alarm {
    	public string Text { get; set;}
    	public int Year { get; set;}
    	public int Month { get; set;}
    	public int Day { get; set;}
    	public int Hour { get; set;}
    	public int Minute { get; set;}
    	
    	public Alarm (string text, int year, int month, int day, int hour, int minute)
    	{
    		Text = text;
    		Year = year;
    		Month = month;
    		Day = day;
    		Hour = hour;
    		Minute = minute;
    	}
    	
    }
