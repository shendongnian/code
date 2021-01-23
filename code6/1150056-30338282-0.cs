    using nsAlias = System.Some.Long.Namespace;
    namespace System
    {
        class TestClass
        {
            static void Main()
            {
                // Using the alias:
                nsAlias.SomeObject test = new nsAlias.SomeObject();
            }
        }
    }
