    using (var context = new MyDbContext())
    {
        var result = cocontext.MyTable.Where(x => x.Column1 = "A" || 
                                                 (x.Column2 == "A" && x.Column3 == "A"));    
    }
