    var idOfRecord=12;
    using(var yourDbContext=new YourDbContext())
    {
      var good=yourDbContext.Goods.FirstOrDefault(s=>s.Id==idOfRecord);
      if(good!=null)
      {
        good.Name = "New name read from UI"; //Updating the Name property value
        yourDbContext.Entry(good).State = EntityState.Modified;
        yourDbContext.SaveChanges();
      }
    }
