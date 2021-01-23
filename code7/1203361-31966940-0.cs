        [Obsolete("Use MyNewAttribute instead")]
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
        public class MyAttribute : Attribute {}
        [AttributeUsage(AttributeTargets.Class)]
        public class MyNewAttribute : Attribute {}
