    Dictionary<string, ScheduleInnerViewModel> dic = new Dictionary<string, ScheduleInnerViewModel>();
    
    dic.Add("01:30", new ScheduleInnerViewModel{ Free = false, Price = 100 });
    dic.Add("04:25", new ScheduleInnerViewModel{ Free = false, Price = 200 });
    dic.Add("13:00", new ScheduleInnerViewModel{ Free = true, Price = 0 });
    
    var json = JsonConvert.SerializeObject(dic, new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented });
    
    Console.WriteLine(json);
