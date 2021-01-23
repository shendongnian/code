      using(var db1 = new Entities1())
      {
          var activitylists = db.Activity.ToList();
          foreach (var item in activitylists )
	      {
              if(item.Id==null)
              {
                  var newActivity= new Activity();
                 //Your entities 
                 newActivity.Name="Name";
                 db.Activity.Add(newActivity);
              }
              else
              {
                item.Name="new name update";
               db.Entry<Activity>(item).State = System.Data.Entity.EntityState.Modified;
              }
	            	 
	       }
           db.SaveChanges();
       }
