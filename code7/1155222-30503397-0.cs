    var resultsFiltered = db.Tables.Where( x=> 
                     myCombinationObjectId1s.Contains(x.Prop1) 
                  || myCombinationObjectId2s.Contains(x.Prop2))
                .AsEnumerable() // everything past that is done in memory but isn't materialized immediately, keeping the streamed logic of linq
                .Where( x=>
                     myCombinationObject
                         .Contains(new {Id1 = x.Prop1, Id2 = x.Prop2 })
                .ToList();
