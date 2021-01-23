      using (var store = new DocumentStore
            {
                Url = "http://localhost.fiddler:8080",
                DefaultDatabase = "Test"            
            })
            {
                store.Initialize();
                using (var session = store.OpenSession())
                {
                    var result = session.Query<Order>().Where(x => 
                    x.Company == "companies/58" && x.Freight < 30m).ToList();                    
                }
            }
