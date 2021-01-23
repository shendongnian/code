    public class ManageUsersPage
    {
        public static void GoTo()
        {
            // Loads page
        }
    
        public static void EditUserAccount(string username)
        {
            Driver.FindElement(By.XPath("//table/tbody/tr[td[1] = '" + username + "']/td[4]/a[1]")).Click();
        }
        
        public static void DeactivateUser(string username)
        {
            Driver.FindElement(By.XPath("//table/tbody/tr[td[1] = '" + username + "']/td[4]/a[2]")).Click();
        }
    
    }
    [TestMethod]
    public void NavigateToEditManageUsers()
    {
        ManageUsersPage.GoTo();
        ManageUsersPage.EditUserAccount("Bill");
    }
