    [ClassInitialize]
    public static void TestClassinitialize(TestContext context)
    {
        var webAppUrl = context.Properties["webAppUrl"].ToString();
       //other settings etc..then use your test settings parameters here...
    }
