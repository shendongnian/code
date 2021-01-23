    namespace ConsoleApp {
        class Program {
            private class Foo {
                // Look Ma!  No attributes!
                public string Id { get; set; }
                public string OtherProperty { get; set; }
            }
            static void Main(string[] args) {
                
                //you would typically do this in the singleton routine you use 
                //to create your dbClient, so you only do it the one time.
			    var pack = new ConventionPack();   
			    pack.Add(new StringObjectIdConvention());
			    ConventionRegistry.Register("MyConventions", pack, _ => true);
  			    // Note that we registered that before creating our client...
			    var client = new MongoClient();
                //now, use that client to create collections
			    var testDb = client.GetDatabase("test");
			    var fooCol = testDb.GetCollection<Foo>("foo");
			    fooCol.InsertOne(new Foo() { OtherProperty = "Testing", Id="TEST" });
			    var foundFoo = fooCol.Find(x => x.OtherProperty == "Testing").ToList()[0];
			    Console.WriteLine("foundFooId: " + foundFoo.Id);
           }
            //obviously, this belongs in that singleton namespace where
            //you're getting your db client.
            private class StringObjectIdConvention : ConventionBase, IPostProcessingConvention {
                public void PostProcess(BsonClassMap classMap) {
                    var idMap = classMap.IdMemberMap;
                    if (idMap != null && idMap.MemberName == "Id" && idMap.MemberType == typeof(string)) {
                        idMap.SetIdGenerator(new StringObjectIdGenerator());
                    }
                }
            }
        }
    }
