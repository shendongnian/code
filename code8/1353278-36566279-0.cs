    List<String> times = new List<String>() {
            "00:00:40",
            "00:01:00",
            "00:02:10" };
    
    String answer = new TimeSpan(times
      .Select(item => TimeSpan.Parse(item).Ticks)
      .Sum())
      .ToString();
    
    // 00:03:50
    Console.Write(answer); 
