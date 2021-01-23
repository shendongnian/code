    public ActionResult Index()
            {
                if (Session["SessionObj"] != null)
                {
                    List<Person> People = (List<Person>)Session["SessionObj"];
                    ViewBag.PeopleList = People;
                }
                else
                {
                    List<Person> People = new List<Person>();
                    Session["SessionObj"] = People;
                }
                return View();
            }
