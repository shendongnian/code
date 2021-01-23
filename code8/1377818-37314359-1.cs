            public ActionResult Index()
            {
                bindCombo();
                return View();
            }
    
            private void bindCombo()
            {
                List<SelectListItem> ObjItem = new List<SelectListItem>()
                {
                    new SelectListItem {Text="Select",Value="Select",Selected=true },
                    new SelectListItem {Text="ASP.NET",Value="ASP.NET" },
                    new SelectListItem {Text="C#",Value="C#"},
                    new SelectListItem {Text="MVC",Value="MVC"},
                    new SelectListItem {Text="SQL",Value="SQL" },
                };
                ViewBag.ListItem = ObjItem;
            }
    
            [HttpPost]
            public ActionResult dropDown(string ListItem)
            {
                ViewBag.SelectedValue = ListItem;
                bindCombo();
                return View("index");
            }
