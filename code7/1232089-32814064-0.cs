    var t1 = TimeSpan.FromHours(8); //Assuming t1 is 8.00 as you said
    foreach(var entry in model)
    {
        list.Time = t1.ToString();
        t1 += TimeSpam.FromMinutes(15);
        db.Entry(list).State = EntityState.Modified;
        db.SaveChanges();
    }
