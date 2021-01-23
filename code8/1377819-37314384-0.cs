        List<SelectListItem> ObjItem = new List<SelectListItem>()
        {
      new SelectListItem {Text="Select",Value="0",Selected=true },
      new SelectListItem {Text="ASP.NET",Value="1" },
      new SelectListItem {Text="C#",Value="2"},
      new SelectListItem {Text="MVC",Value="3"},
      new SelectListItem {Text="SQL",Value="4" },
        };
        public ActionResult Index()
        {
            ViewBag.ListItem = ObjItem;
            return View("Index");
        }
        public ActionResult dropDown(string ListItem)
        {
            ViewBag.ListItem = ObjItem;
            ViewBag.SelectedValue = ObjItem.Where(i => i.Value == ListItem).FirstOrDefault().Text;
            return this.View("Index");
        }
