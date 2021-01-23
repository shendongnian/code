    List<String> times = new List<String>() {
      "00:00:40",
      "00:01:00",
      "00:02:10"};
    
    var totalTime = new TimeSpan(times
      .Select(item => TimeSpan.Parse(item).Ticks)
      .Sum());
    
    // 00:03:50
    Console.Write("Total Time: {0}", totalTime); 
