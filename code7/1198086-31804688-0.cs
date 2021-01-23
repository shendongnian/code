    public class SomeClass
    {
        public bool SomeMethod()
        {
            var session = HttpContext.Current.Session;
            if (session["someSessionData"].ToString() == "OK")
                return true;
            return false;               
        }
    }
    [TestMethod]
    public void SomeTestMethod()
    {
        using (ShimsContext.Create())
        {
            var instanceToTest = new SomeClass();
    
            var session = new System.Web.SessionState.Fakes.ShimHttpSessionState();
            session.ItemGetString = (key) => { if (key == "someSessionData") return "OK"; return null; };
    
            var context = new System.Web.Fakes.ShimHttpContext();
            System.Web.Fakes.ShimHttpContext.CurrentGet = () => { return context; };
            System.Web.Fakes.ShimHttpContext.AllInstances.SessionGet =
                (o) =>
                {
                    return session;
                };
            
            var result = instanceToTest.SomeMethod();
            Assert.IsTrue(result);
        }
    }
