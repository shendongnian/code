    var t1 = TimeSpan.FromHours(8); //Assuming t1 is 8.00 as you said
    var iii = -1;
    foreach(var entry in model)
    {
        list.Time = t1.ToString() + TimeSpan.FromMinutes(++iii * 15);
        db.Entry(list).State = EntityState.Modified;
        db.SaveChanges();
        if(iii == 3)
            iii = -1;
    }
