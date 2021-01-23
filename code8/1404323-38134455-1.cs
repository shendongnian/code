    public ActionResult Test()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Text = "1",
                Value = "1"
            });
            lista.Add(new SelectListItem()
            {
                Text = "2",
                Value = "2"
            });
            lista.Add(new SelectListItem()
            {
                Text = "3",
                Value = "3"
            });
            lista.Add(new SelectListItem()
            {
                Text = "4",
                Value = "4"
            });
            lista.Add(new SelectListItem()
            {
                Text = "5",
                Value = "5"
            });
            ViewBag.list = lista;
            return View(new CustomViewModel());
        }
        [HttpPost]
        public ActionResult Test(CustomViewModel customViewModel)
        {
            //your code
            //if return the same view create again the List<SelectListItem>
            return View(customViewModel);
        }
