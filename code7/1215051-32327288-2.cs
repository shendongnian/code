        [HttpPost]
        public JsonResult Opticians(Guid? Id)
        {
            var opticianList = db.Opticans.Where(a => a.PracticeId == Id).Select(a => a.User).ToList();
            SelectList mySelectList = new SelectList(opticianList, "IDField", "DisplayField", 0);
    
            return Json(mySelectList );
        }
