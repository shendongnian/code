    namespace Library1
    {
        [CompilationMapping(SourceConstructFlags.Module)]
        public static class MyModule
        {
            public static string fOnly<a>(a x)
            {
                "Dynamic invocation of get_Foo is not supported";
                throw new NotSupportedException();
            }
            public static string testFOnly()
            {
                Class1 @class = new Class1();
                return "F#";
            }
        }
    }
