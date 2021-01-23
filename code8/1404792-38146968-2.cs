        public ActionResult Books(string catalogId)
        {
            int catId = Convert.ToInt32(catalogId);
            var model = new BookViewModel()
            {
                Books = Books().Where(x => x.CatalogId == catId).ToList()
            };
            return PartialView("Partials/_BooksDropDownList", model);
        }
