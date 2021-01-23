    async void Main()
    {
    
      var client = new MongoClient("mongodb://localhost");
      var db = client.GetDatabase("TestSPLike");
      var col = db.GetCollection<Rule>("rules"); 
    
      await client.DropDatabaseAsync("TestSPLike"); // recreate if exists
      await InsertSampleData(col); // save some sample data
    
      var data = await col.Find( new BsonDocument() ).ToListAsync();
      //data.Dump("All - initial");
      
    /*  
      db.rules.aggregate(
       [
         { $match: 
            {
             "Active":true
            }
         }, 
         { $project: 
            { 
             Name: 1, 
             Active: 1, 
             Weight:1, 
             Produce: { $multiply: [ "$Weight.Unit", "$Weight.Value" ] }
            } 
         },
         { $match: 
            {
              Produce: {"$gt":5}
            }
         }
       ]
    )
    */ 
    
    var aggregate = col.Aggregate()
      .Match(new BsonDocument{ {"Active", true} })
      .Project( new BsonDocument {
          {"Name", 1}, 
          {"Active", 1}, 
          {"Weight",1}, 
          {"Produce", 
             new BsonDocument{
               { "$multiply", new BsonArray{"$Weight.Unit", "$Weight.Value"} }
            }} 
      } )
      .Match( new BsonDocument { 
           { "Produce", 
              new BsonDocument{ {"$gt",5} } 
              }
              })
      .Project( new BsonDocument {
          {"Name", 1}, 
          {"Active", 1}, 
          {"Weight",1} 
          } );
      var result = await aggregate.ToListAsync();
      //result.Dump();
    }
    
    private async Task InsertSampleData(IMongoCollection<Rule> col)
    {
     var data = new List<Rule>() {
       new Rule { Name="Rule1", Active = true, Weight = new Weight { Unit=1, Value=10} },
       new Rule { Name="Rule2", Active = false, Weight = new Weight { Unit=2, Value=3} },
       new Rule { Name="Rule3", Active = true, Weight = new Weight { Unit=1, Value=4} },
       new Rule { Name="Rule4", Active = true, Weight = new Weight { Unit=2, Value=2} },
       new Rule { Name="Rule5", Active = false, Weight = new Weight { Unit=1, Value=5} },
       new Rule { Name="Rule6", Active = true, Weight = new Weight { Unit=2, Value=4} },
     };
      
     await col.InsertManyAsync( data,new InsertManyOptions{ IsOrdered=true});
    }
    
    public class Weight
    {
      public int Unit { get; set; }
      public int Value { get; set; }
    }
    
    public class Rule
    {
      public ObjectId _id { get; set; }
      public string Name { get; set; }
      public bool Active { get; set; }
      public Weight Weight { get; set; }
    }
