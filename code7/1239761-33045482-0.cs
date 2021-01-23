    [TestMethod]
    [TestCategory("Smoke")]
    [TestCategory("regression")]
    public void Login()
    {
        var method = MethodBase.GetCurrentMethod();
        foreach(var attribute in (IEnumerable<TestCategoryAttribute>)method
            .GetCustomAttributes(typeof(TestCategoryAttribute), true))
        {
            foreach(var category in attribute.TestCategories)
            {
                Console.WriteLine(category);
            }
        }
        var categories = attribute.TestCategories;  
    }
