        public ActionResult Index(FotoModel model)
        {
            if (model != null && model.File != null)
            {
                var fileSize = model.File.ContentLength;
            }
        }
