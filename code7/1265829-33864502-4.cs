        [HttpPost]
        public JsonResult CreateDirectory()
        {
            if (!Directory.Exists(Server.MapPath("~/Content/Essential_Folder/")))
            {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Content/Essential_Folder/NewDir_{0}",
                DateTime.Now.Millisecond)));
                return Json("OK");
            }
            return Json("NO");
        }
