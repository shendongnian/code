    var tableAEntity = new TableAEntity
    {
     // set tableA fields
     // Name = "blah",
     // now set the TableB navigation property reference
     TableBEntityField = new TableBEntity
                         {
                          // table B fields
                         }
    };
    
    context.TableAEntities.Add(tableAEntity);
    context.SaveChanges() 
 
