        public ActionResult Index()
                {
                    if (Session["StudentSession"] != null)
                    {
                        List<Student> Students = (List<Person>)Session["StudentSession"];
                        // do something
                    }
                    else // create a new session so you can do w/e
                    {
                        List<Student> Students = new List<Student>();
                        Session["StudentSession"] = Students;
                    }
                    return View();
                }
