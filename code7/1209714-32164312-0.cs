    // ID is your primary key
    long startID = 0;
    while(true){
        using(var db = new CustomDbContext()){
            var slice = db.Items.Where(x=>x.ID > startID)
                                .OrderBy(x=>x.ID)
                                .Take(1000).ToList();
            // stop if there is nothing to process
            if(!slice.Any())
                 break;
            foreach(var item in slice){
                // your logic...
                item.Converted = true;
            }
            startID = slice.Last().ID;
        }
    }
