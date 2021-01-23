        [XmlRoot("Foo")]
        public class FooSurrogate
        {
            public string Name { get; set; }
            public string Bar_Data { get; set; }
            public string Bar_MoreData { get; set; }
            public Foo ToFoo()
            {
                return new Foo
                {
                    Name = Name,
                    Bar = new Bar
                    {
                        Data = Bar_Data,
                        MoreData = Bar_MoreData
                    }
                };
            }
        }
        var seializer = new XmlSerializer(typeof (FooSurrogate));
        var foo = ((FooSurrogate) seializer.Deserialize(...)).ToFoo();
