        public ActionResult XData(string id)
        {
            string dir = WebConfigurationManager.AppSettings["X_Path"];
            //search for the file
            if (Directory.Exists(dir) && System.IO.File.Exists(Path.Combine(dir, id, "X.json")))
            {
                //read the file
                string contents = System.IO.File.ReadAllText(Path.Combine(dir, id, "X.json"));
                //return contents of the file as json
                return Content(contents, "application/json");
            }
            return new HttpNotFoundResult();
        }
