    public ActionResult Index()
            {   
                var enumDataColours = from CSSColours e in Enum.GetValues(typeof(CSSColours))
                               select new
                               {
                                   ID = StaticHelper.GetDescriptionOfEnum((CSSColours)e),
                                   Name = e.ToString()
                               };
                ViewBag.EnumColoursList = new SelectList(enumDataColours, "ID", "Name");
                return View();
            }
