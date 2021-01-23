    var g = usages.GroupBy(r => r.Alias); 
    foreach (var u in g) 
    { 
        var x = u.GroupBy(r => r.HitDate.Day)
                 .Select(gr => new { 
                                       Alias=u.Alias,
                                       HitDate=gr.Key, 
                                       Count=gr.Count() 
                 }); 
        foreach (var m in x) 
        {
            Console.WriteLine(m.HitDate + " " + m.Count); 
        } 
    } 
