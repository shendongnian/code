        public class Product
        {
            public virtual Guid Id { get; set; }
            public virtual string Name { get; set; }
            public virtual string Type { get; set; }
        }
        public class ProductFull : Product
        {
            public override Guid Id { get; set; }
            public override string Name { get; set; }
            public override string Type { get; set; }
            public List<Item1> Item1s { get; set; }
            public List<Item2> Item2s { get; set; }
        }
        public class Item1
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
        public class Item2
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
