    public static class ExampleClass
    {
        public class InnerIsExist
        {
            private string[] words = new string[] { "Word1", "Word2", "Word3", "Word4", "Word5" };
            public bool this[string word]
            {
                get {  return words.Contains(word); }
            }
        }
        public static InnerIsExist IsExist { get; } = new IsExistClass();
    }
