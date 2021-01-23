    string step = "0001-02-03.01:00:00";
    
    string[] parts = step.Split(new string[] {"-", "."}, StringSplitOptions.None);
    
    TimeSpan hours = TimeSpan.Parse(parts[3]);
    TimeSpan days = new TimeSpan(int.Parse(parts[2]), 0, 0, 0);
    TimeSpan months = new TimeSpan(int.Parse(parts[1]) * 30, 0, 0, 0);
    TimeSpan years = new TimeSpan(int.Parse(parts[0]) * 360, 0, 0, 0);
    TimeSpan total = hours.Add(days).Add(months).Add(years);
    
    Console.WriteLine(total.ToString());
