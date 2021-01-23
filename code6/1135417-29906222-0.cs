        public class Foo
        {
            public Foo()
            {
                this.Id = Guid.NewGuid()
                              .ToString();
            }
        
            public string Id { get; set; }
        }
