        public void SavePersonData(TestPerson person)
        {
            // You no longer need to deserialize as you'll have data properly mapped to the TestPerson object.
            //var dataObject = Request.Form["person"];
            //var serializer = new JavaScriptSerializer();
            //object personReport = serializer.DeserializeObject(dataObject);
            person.File = (byte[])Session["UploadedPhoto"];
            System.Console.WriteLine("dummy line");
        }
        public JsonResult CacheUploads(HttpPostedFileBase personPhoto)
        {
            byte[] photoAsBytes = null;
            using (var binaryReader = new BinaryReader(personPhoto.InputStream))
            {
                photoAsBytes = binaryReader.ReadBytes(personPhoto.ContentLength);
            }
            Session.Add("UploadedPhoto", photoAsBytes);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
