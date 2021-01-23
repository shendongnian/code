    public ActionResult ProcessProducts(){
        Parallel.ForEach(DB.Products, p=>{
             p.Processed = true;
             // this fails, as p.Orders query is fired
             // from same DbContext in multiple threads
             foreach(var order in p.Orders){
                 order.Processed = true;
             }
        });
        DB.SaveChanges(); 
    }
