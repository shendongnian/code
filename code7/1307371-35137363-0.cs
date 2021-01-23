     public ICollection<ChildEntity> ChildEntitiesEnabled()
     {
          //First I get the full list using the lazy loading...
          var allChildEntities=ChildEntities.ToList();
          //do further processing if there is data
          if(allChildEntities!=null && allChildEntities.Count()>0)
          {
             var childEntitiesEnabled =  ChildEntities.Where(x=>x.Enabled==true).ToList();
             return childEntitiesEnabled;
          }
          return null; //or you can return an empty list...
     }
