        public class Collection
        {
        }
    
        public class CatalogOnly
        {
        }
    
        public class RootObject
        {
            public string title { get; set; }
            public string slug { get; set; }
            public Collection collection { get; set; }
            public CatalogOnly catalog_only { get; set; }
            public object configurator { get; set; }
        }
        var k = JsonConvert.SerializeObject(new RootObject
                    {
                        catalog_only =new CatalogOnly(),
                        collection = new Collection(),
                        configurator =null,
                        slug="Test",
                        title="Test"
                    });
        var t = JsonConvert.DeserializeObject<RootObject>(k).configurator;
