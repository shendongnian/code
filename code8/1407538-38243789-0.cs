    [DataContract] 
    public class Parent 
    {
        private Parent() {}
        [DataMember(Name="id")]
        public int? Id { get; private set; }
        [DataMember(Name = "value")]
        public int? Value { get; private set; }
        public static Parent CreateWithId(int id)
        {
            return new Parent { Id = id };
        }
        public static Parent CreateWithValue(int value)
        {
            return new Parent { Value = value };
        }
    }
