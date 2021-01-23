        public static void MyFunction(object obj)
        {
            Foo foo;
            Bar bar;
            if ((foo = obj as Foo) != null)
                 //Work with foo here.
            else if ((bar = obj as Bar) != null)
                 //Work with bar here
        }
