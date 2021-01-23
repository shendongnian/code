        public abstract class SuperClass
        {
            public string SuperProperty { get; set; }
        }
        public abstract class IntermediateClass : SuperClass
        {
             public string IntermediateProperty { get; set; }
        }
        public class ChildClass : BaseClass
        {
            public string ChildProperty { get; set; }
        }
