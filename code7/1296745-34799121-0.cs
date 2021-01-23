    namespace ConsoleApp {
        class Program {
            private class Foo {
                // Look Ma!  No attributes!
                public string Id { get; set; }
                public string OtherProperty { get; set; }
            }
            static void Main(string[] args) {
                var pack = new ConventionPack();   //This is a MongoDB object.
                pack.Add(new StringObjectIdConvention());
                ConventionRegistry.Register("MyConventions", pack, _ => true);
    
                // Note that we registered that before creating our client...
                var client = new MongoClient();
                var testDb = client.GetServer().GetDatabase("test");
                var fooCol = testDb.GetCollection<Foo>("foo");
                fooCol.Drop();
                fooCol.Save(new Foo());
                var fooColBson = testDb.GetCollection("foo");
                var fooDoc = fooColBson.FindOne();
                Debug.Assert(fooDoc["_id"].IsObjectId);
           }
            private class StringObjectIdConvention : ConventionBase, IPostProcessingConvention {
                public void PostProcess(BsonClassMap classMap) {
                    var idMap = classMap.IdMemberMap;
                    if (idMap != null && idMap.MemberName == "Id" && idMap.MemberType == typeof(string)) {
                        idMap.SetRepresentation(BsonType.ObjectId);
                        idMap.SetIdGenerator(new StringObjectIdGenerator());
                    }
                }
            }
        }
    }
