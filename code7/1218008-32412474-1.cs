    public ActionResult ProcessProducts(){
        foreach(var p in DB.Products){
           p.Processed = true;
           foreach(var order in p.Orders){
              order.Processed = true;
           }
        }
        DB.SaveChanges();
    }
