    [TestMethod]
    public void list__all_unit_tests()
    {
        string sDLL = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        string sFilePath = string.Format("{0:s}\\{1:s}.DLL", System.IO.Directory.GetCurrentDirectory(), sDLL);
        var assembly = System.Reflection.Assembly.LoadFile(sFilePath);
        var testClasses = assembly.GetTypes()
                    .Where(m => m.GetCustomAttributes(typeof(TestClassAttribute),false)!=null);
        foreach (var testClass in testClasses)
        {
            var testMethods = testClass.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute),true).Length !=0);
            foreach (var testMethod in testMethods)
            {
                Debug.Print(string.Format("class,{0:s}, method,{1:s} ", testClass.FullName , testMethod.Name));
            }
        }
    }
