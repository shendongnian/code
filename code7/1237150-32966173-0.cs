    public ActionResult Error(int? page)
    {
        var model = _privateObjForReturningStuff.GetPage(page);
        return View(model);
    }
    public class ForReturningStuff
    {
        public Model GetPage(int page)
        {
            ... gets page stuff
        }
    }
    [TestClass]
    public class ForReturningStuffTest
    {
        [TestMethod]
        public void GetPage_does_something_I_can_assert()
        {
            ...
        }
    }
