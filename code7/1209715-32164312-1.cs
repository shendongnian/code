    public IEnumerable<IEnumerable<T>> Slice(IEnumerable<T> src, int size){
         while(src.Any()){
             var s = src.Take(size);
             src = src.Skip(size);
             yield return s;
         }
    }
    long startID = 0;
    while(true){
        using(var db = new CustomDbContext()){
            var src = db.Items.Where(x=>x.ID > startID)
                                .OrderBy(x=>x.ID)
                                .Take(10000).Select(x=>x.ID).ToList();
            // stop if there is nothing to process
            if(!src.Any())
                 break;
            Parallel.ForEach(src.Slice(100), slice => {
                 using(var sdb = new CustomDbContext()){
                     foreach(var item in sdb.Items.Where(x=> slice.Contains(x.ID)){
                         item.Converted = true;
                     }
                 }
            } );
            startID = src.Last();
        }
    }
