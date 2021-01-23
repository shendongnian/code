    using(PlanGenEntities3 db = new PlanGenEntities3()){
         IList<Entity> list = new List<Entity>();
         var query = db.Get_ListOf_Holiday();
         foreach (var m in query)
         {
           list.Add(new Entity()
           {
             Id = m.Id,
             Name = m.Name             
           });
          }
          return list;
    }
