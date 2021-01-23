      var query2 = (from contact in contacts
                                     join callLog in callLogs on contact.Phone equals callLog.Number into joined
                                     from callLog in joined.Where(p=>p.Incoming == true).DefaultIfEmpty()
            
                                     select new
                                     {
                                         who = contact.FirstName + " " + contact.LastName + " " + contact.Phone,
                                         how_many = callLog != null ? callLogs.Where(s =>s.Number == contact.Phone).Count() : 0
                                     }).Select(p=>p).Distinct();
    foreach (var q in query2)
    {
      Console.WriteLine(q.who + " " + q.how_many);
    }
