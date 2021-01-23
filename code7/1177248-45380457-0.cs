    public FooClass GetFirstFooDocument(string templatename)
            {
                var coll = db.GetCollection<FooClass>("foo");
                FooClass foo = coll.Find(_ => _.TemplateName == templatename).FirstOrDefault();
                return foo; 
            }
