    var hours = new[] {
                            new { Date = "21/04/2008", Person = "Sally", Hours= 3 },
                            new { Date = "21/04/2008", Person = "Sam", Hours = 15 },
                            new { Date = "22/04/2008", Person = "Sam", Hours = 8 },
                            new { Date = "22/04/2008", Person = "Sally", Hours = 9 },
                            new { Date = "22/04/2008", Person = "John", Hours = 5 },
                            new { Date = "22/04/2008", Person = "John", Hours = 2 },
                            new { Date = "22/04/2008", Person = "Tom", Hours = 9 },
                       };
    var result = new Dictionary<string, Dictionary<string, int>>();
    foreach (var workLog in hours)
    {
        if (!result.ContainsKey(workLog.Date))
            result[workLog.Date] = new Dictionary<string, int>();
        if (!result[workLog.Date].ContainsKey(workLog.Person))
            result[workLog.Date][workLog.Person] = 0;
        result[workLog.Date][workLog.Person] += workLog.Hours;
    }
    Console.WriteLine(JsonConvert.SerializeObject(result));
