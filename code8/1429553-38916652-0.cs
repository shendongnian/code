    Public Static Class FW_Shared
    {
        public static string OrgCode = "Test123";
        public static string Username = "Tester";
        public static string Password = "Password";
    
        public static bool Perform_Login(string OrgCode, string Username, string Password)
        {
            Try
            {
                Driver.Url = "http://test.app.com/";
                Driver.FindElement(By.Id("org_code")).SendKeys(OrgCode);
                Driver.FindElement(By.Id("username")).SendKeys(Username);
                Driver.FindElement(By.Id("password")).SendKeys(Password);
                Driver.FindElemenet(By.Id("btnsubmit)).Click();
            }
            Catch (Exception ex)
            {
                 Console.WriteLine(@"Error occurred logging on: " + ex.ToString());
                 return false;
            }
            return true;
        }
    }
    [TestMethod]
    Public Void TestLoginSuccess()
    {
        Assert.IsTrue(FW_Shared.Perform_Login(FW_Shared.OrgCode, FW_Shared.Username, FW_Shared.Password));
        Console.WriteLine(@"Login Successful");    
    }
    [TestMethod]
    Public Void TestLoginFailure()
    {
        Assert.IsFalse(FW_Shared.Perform_Login(FW_Shared.OrgCode, “foo”, “bar”));
        Console.WriteLine(@"Login Failed");    
    }
