    //To get the inserted id 
    var anonymousprojectList = (new[] { new { FirstCollectionId= 0, SecondCollectionId= 0, ThirdObject= new Document() } }).ToList();
    using (var db = new DemoEntities())
        {
            //Setting Auto Detech Changes false when starting loop
            db.Configuration.AutoDetectChangesEnabled = false;
            //Looping start
            collection.ForEach(myitem =>
                {
                    myitem.SecondCollection.ForEach(secondLevel =>
                        {
                                 //Some Operation Over here
                            secondLevel.ThirdCollection.ForEach(thirdItem =>
                                {
                                    var myEntity= new MyTable()
                                    {
                                        Level=thirdItem.Name,
                                        Method=thirdItem.Method,
                                      Representation=thirdItem.Representation,
                                    };
                                    var insertedItem = db.MyTable.Add(myEntity);
                                    //Setting the reference of id to the 
                                    //DTO after the save changes. 
                                    //This seems always 0 as it this time
                                    // it have no id only after save changes the id be passed into InsertedItem , I have to pass the reference to myDTO also
                                    using (var db = new DemoEntities())
        {
            //Setting Auto Detech Changes false when starting loop
            db.Configuration.AutoDetectChangesEnabled = false;
            //Looping start
            collection.ForEach(myitem =>
                {
                    myitem.SecondCollection.ForEach(secondLevel =>
                        {
                                 //Some Operation Over here
                            secondLevel.ThirdCollection.ForEach(thirdItem =>
                                {
                                    var myEntity= new MyTable()
                                    {
                                        Level=thirdItem.Name,
                                        Method=thirdItem.Method,
                                      Representation=thirdItem.Representation,
                                    };
                                    var insertedItem = db.MyTable.Add(myEntity);
                                    //Setting the reference of id to the 
                                    //DTO after the save changes. 
                                    //This seems always 0 as it this time
                                    // it have no id only after save changes the id be passed into InsertedItem , I have to pass the reference to myDTO also
                                    anonymousprojectList.Add(new {FirstCollectionID = myItem.Od,SecondCollectionId=secondLevel.Id,ThirdObject = insertedItem});
                                });
                        });
                });
            //Setting Auto Detech Changes true when starting loop
            db.Configuration.AutoDetectChangesEnabled = true;
            // Here I save my changes
            db.SaveChanges();
                                });
                        });
                });
            //Setting Auto Detech Changes true when starting loop
            db.Configuration.AutoDetectChangesEnabled = true;
            // Here I save my changes
            db.SaveChanges();
       }
           // Loop through the anonymous collection and assign to the input collection itself 
           //Skip header item
           anonymousprojectList.Skip(1).ToList().ForEach(object=>
            {
              //Loop through the three level and assign the value
                            
              //Assign the value
              ThirdlevelItem.Id = ThirdObject.Id) 
            });
    return collection
