    [DataContract] 
    public class Parent 
    {
        [DataMember(Name="id")]
        public int Data { get; private set; }
        [DataMember(Name="id")]
        public ParentType ParentType { get; private set; }
        public static Parent CreateWithId(int id)
        {
            return new Parent { Data = id, ParentType = ParentType.Id };
        }
        public static Parent CreateWithValue(int value)
        {
            return new Parent { Data = value, ParentType = ParentType.Value };
        }        
    } 
