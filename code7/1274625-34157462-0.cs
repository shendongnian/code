        [HttpGet]
        public PartialViewResult AlternateMaterialNotes()
        {
            string remarks = " ";
            return PartialView(((object)remarks));
        }
        [HttpPost]
        public JsonResult AlternateMaterialNotes(string PartNumber = null)
        {
            IPartSearch part=null;
            string remarks= " ";
            if (PartNumber != null)
            {
                part = _partSearch.GetPart(PartNumber.Trim());
                remarks = part != null ? part.Remarks : null;
            }
            return Json(remarks);
        }
