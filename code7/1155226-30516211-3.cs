    DbSet<CombinationObjectTable> combinationObjectTable = context.Set<CombinationObjectTable>();
    StringBuilder wholeQuery = new StringBuilder("DELETE * FROM CombinationObjectTable");
    foreach(var obj in myCombinationObject)
    {
        wholeQuery.Append(string.Format("INSERT INTO CombinationObjectTable(Id1, Id2) VALUES('{0}', '{1}')", obj.Id1, obj.Id2);
    }
    wholeQuery.Append(
        db.Tables
            .Where( x=> 
                     myCombinationObjectId1s.Contains(x.Prop1) 
                  || myCombinationObjectId2s.Contains(x.Prop2))
            .Where( x=>
               combinationObjectTable.Any(ct => ct.Id1 == x.Id1 && ct.Id2 == x.Id2)
            ).ToString();
        );
     var filteredResults = context.Tables.ExecuteQuery(wholeQuery.ToString());
