    namespace MyProject
    {
        public abstract class MyAbstractThing
        {
            protected const uint Percentage = 42;
        }
    
        public sealed class MyThing : MyAbstractThing
        {
            public new const uint Percentage = MyAbstractThing.Percentage;
            //                                 ^^^^^^^^^^^^^^^
        }
    }
