    var dataPackage = from c in db.company select new { 
                    c.IsDeluxe,
                    c.Address,
                    c.RevenueRange,
                    c.CompanyAge };
    var actualItems = new List<SomeObject>();
    foreach(var item in dataPackage)
    {
         var addingItem = new SomeObject();
         
         if(item.IsDeluxe)
         {
             //Initialize some object one way
         }
         else
         {
             //Initialize some object another way
         }
         actualItems.Add(adding);
    }
