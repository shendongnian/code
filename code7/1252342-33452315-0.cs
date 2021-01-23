     [HttpPost]
        public ActionResult Create(Foo foo)
        {
            try
            {
                var _objddContext = new DBContext();
                if (_objdBentityContext != null)
                {
                    _objdBentityContext.FoosEntity.Add(foo);
                }
                else
                {
                    _objdBentityContext.FoosEntity = new FoosEntity();
                    _objdBentityContext.FoosEntity.Add(foo);
                }
                _objdBentityContext.FoosEntity.SaveChanges()
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
