        public ActionResult DropDownListTest()
        {
            var myList = new List<SelectListItem>();
            myList.Add(new SelectListItem { Text = "Darren one", Value = "1" });
            myList.Add(new SelectListItem { Text = "Darren two", Value = "2" });
            myList.Add(new SelectListItem { Text = "Darren three", Value = "3" });
            ViewBag.DarrenList = myList;
            return View();
        }
