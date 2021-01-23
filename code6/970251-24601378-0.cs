    List<Contact> contacts = Contact.SampleData();
    List<CallLog> callLogs = CallLog.SampleData();
    
    var q = from callLog in callLogs
            group callLog by callLog.Number into g
            join c in contacts on g.Key equals c.Phone
            let row = new { g = g, c = c }
            group row by row.g.Count() into g2
            select new
            {
                People = g2.Select((x) => x.c.FirstName).ToArray(),
                Count = g2.Key
            };
    
    foreach (var qq in q)
    {
        Console.WriteLine(qq.Count + ": " + string.Join(", ", qq.People));
    }
