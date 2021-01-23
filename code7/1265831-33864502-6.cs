        [HttpPost]
        public JsonResult CreateDirectory()
        {
            //if location has folder called "Essential_Folder" it should allow to goto inside of this if condition
            if (Directory.Exists(Server.MapPath("~/Content/Essential_Folder/")))
            {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/Content/Essential_Folder/NewDir_{0}",
                DateTime.Now.Millisecond)));
                return Json("OK");
            }
            return Json("NO");
        }
