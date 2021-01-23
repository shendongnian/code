    public class DoSerializeAttribute : Attribute {} 
    public class C : B {
        [DoSerialize]
        public MyMember { get; set; }
    }
