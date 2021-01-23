        [HttpGet]
        public PartialViewResult AMN()
        {
            string remarks = " ";
            return PartialView(((object)remarks));
        }
        [HttpPost]
        public JsonResult AMN(string PN = null)
        {
            IPS p=null;
            string remarks= " ";
            if (PN != null)
            {
                p = _pS.GetP(PN.Trim());
                remarks = p != null ? p.Remarks : null;
            }
            return Json(remarks);
        }
