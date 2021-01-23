    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                var model = new List<A>
                {
                    new A {
                            TestB1 = new B { Name = "a", ForeignId = "a1", Value = 1 },
                            TestB2 = new B[]
                            {
                                new B { Name = "b", ForeignId = "b2", Value = 2},
                                new B { Name = "c", ForeignId = "c3", Value = 3}
                            }
                         },
                    new A {
                            TestB1 = new B { Name = "aa", ForeignId = "aa1", Value = 1 },
                            TestB2 = new B[]
                            {
                                new B { Name = "bb", ForeignId = "bb2", Value = 2},
                                new B { Name = "cc", ForeignId = "cc3", Value = 3}
                            }
                         },
                    new A {
                            TestB1 = new B { Name = "aaa", ForeignId = "aaa1", Value = 1 },
                            TestB2 = new B[]
                            {
                                new B { Name = "bbb", ForeignId = "bbb2", Value = 2},
                                new B { Name = "ccc", ForeignId = "ccc3", Value = 3}
                            }
                         }
                };
                return View(model);
            }
            [HttpPost]
            public JsonResult Index(List<A> model)
            {
                return Json("a");
            }
        }
