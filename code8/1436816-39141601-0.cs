    public class ExampleClass
    {
        public class IsExistHelper
        {
            private static string[] words = new string[] { "Word1", "Word2", "Word3", "Word4", "Word5" };
            public bool this[string Word]
            {
                get
                {
                    return words.Any(w => w == Word);
                }
            }
        }
        public static IsExistHelper IsExist { get; } = new IsExistHelper();
    }
