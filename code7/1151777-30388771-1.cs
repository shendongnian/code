    public static class MyExtensions
    {
        public static void MyExtensionMethod(this MyType myType)
        {
            MyDataContextFactory.CreateContext().DoAwesomeThing();
        }
    }
