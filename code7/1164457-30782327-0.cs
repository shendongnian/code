        public ActionResult GetDocument(int id)
        {
            TempVM model = GetViewModel();
            if (model.PDF_Data.Length > 0)
            {
                return File(model.PDF_Data, model.PDF_ContentType);
            }
            else
            {
                return View("NotFound");
            }
        }
