    TimeSpan StartTime = TimeSpan.FromHours(8);
    int Difference = 30; //In minutes.
    int EntriesCount = 10;
    Dictionary<TimeSpan, TimeSpan> Entries = new Dictionary<TimeSpan, TimeSpan>();
    
    for(int i = 0; i < EntriesCount; i++){
    	Entries.Add(StartTime.Add(TimeSpan.FromMinutes(Difference * i)),
    				StartTime.Add(TimeSpan.FromMinutes(Difference * i + Difference)));
    }
    
    foreach(var e in Entries){
    	Console.WriteLine("In: " + e.Key + " - Out: " + e.Value);
    }
