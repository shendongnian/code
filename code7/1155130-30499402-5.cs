    var items = new[] {
        new Record(1, DateTime.Now, DateTime.Now.AddHours(1)),
        new Record(1, DateTime.Now, DateTime.Now.AddHours(1)),
        new Record(1, DateTime.Now, DateTime.Now.AddHours(1))};
    var total=items.Sum(h=>(h.EndDateTime-h.StartDateTime));
    var grouped= (from t in items
                    group t by t.ClientId into z
                    select new
                    {
                        ClientId = z.Key,
                        TimeSpanClientTotal = z.Sum(h => (h.EndDateTime - h.StartDateTime))
                    }).ToList();
