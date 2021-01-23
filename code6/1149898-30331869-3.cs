    namespace MyApp
    {
        using MyApp.Extensions;
        
        public class TestClass
        {
            public TestClass()
            {
                var item = new piece();
                var clone = piece.CloneJson();
            }
        }
    }
