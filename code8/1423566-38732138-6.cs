    public static class HelloWorldAliases
    {
            [CakeMethodAlias]
            public static void HelloWorld(this ICakeContext context)
            {
                 context.Log.Information("Hello {0}", "World");
            }
    }
