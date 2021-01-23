    public static class HelloWorldAliases
    {
            [CakeMethodAlias]
            [CakeNamespaceImport("MyNameSpace.Common")]
            public static void HelloWorld(this ICakeContext context)
            {
                 context.Log.Information("Hello {0}", "World");
            }
    }
