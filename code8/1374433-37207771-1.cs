    public class DemoListController : Controller
        {
            public ActionResult Index()
            {
                var oVm = new MyViewModel
                {
                    movies = new List<Movies>
                    {
                        new Movies {ID=1,Name="Test1",IsSelected=false},
                        new Movies {ID=2,Name="Test2",IsSelected=false},
                        new Movies {ID=3,Name="Test3",IsSelected=false},
                        new Movies {ID=4,Name="Test4",IsSelected=false},
                        new Movies {ID=5,Name="Test5",IsSelected=false}
                    },
                };
                return View(oVm);
            }
    
            public JsonResult GetList(int id)
            {
                var list = new List<Movies>
                    {
                        new Movies {ID=1,Name="Test1",IsSelected=false},
                        new Movies {ID=2,Name="Test2",IsSelected=false},
                        new Movies {ID=3,Name="Test3",IsSelected=false},
                        new Movies {ID=4,Name="Test4",IsSelected=false},
                        new Movies {ID=5,Name="Test5",IsSelected=false}
    
                };
    
                List<Movies> select = new List<Movies>();
                select = list.Where(x => x.ID == id).ToList();
                return new JsonResult { Data = select, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
