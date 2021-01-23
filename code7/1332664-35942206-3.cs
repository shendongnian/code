    public JsonResult SaveComment(string saveNote, string labelId, string orderNumber, string comment, string criteria, HttpPostedFileBase file)
        {
           [text input named saveNote went into saveNote param]
           [file input named file went into HttpPostedFileBase file param]
           
           [...process other params...]
            var ms = new MemoryStream();
            file.InputStream.CopyTo(ms);
            deliveryItemComment.Attachment = ms.ToArray();
            db.SaveChanges();
            var result = "Note Succesfully Added";
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
