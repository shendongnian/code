        [HttpPost]
        [Route("List/{id}")]
        [ActionName("List")]
        public FileResult RequestFile(int? docid)
        {
            if (docid == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Downloads downloads = db.Downloads.Find(docid);
           if (downloads == null)
                return HttpNotFound();
            if (downloads.FileData != null)
            {
                string fileName = downloads.Filename;
                return File(downloads.FileData.Data, System.Net.Mime.MediaTypeNames.Application.Pdf, fileName);
            }
