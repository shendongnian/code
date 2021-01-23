    // NOTE: Original return type: FileContentResult, Changed to ActionResult to allow for error results
    [Route("{docid}/Label")]
    public ActionResult Label(Guid docid) {
        var timestamp = DateTime.Now;
        var shipment = objectFactory.Create<Document>();
        if (docid!= Guid.Empty) {
            var documents = reader.GetDocuments(docid);
            if (documents.Length > 0)
                document = documents[0];
            
                MemoryStream memoryStream = new MemoryStream();
                var printer = MyPDFGenerator.New();
                printer.PrintToStream(document, memoryStream);
                Response.AppendHeader("Content-Disposition", "inline; filename=" + timestamp.ToString("yyyyMMddHHmmss") + ".pdf");
                return File(memoryStream.ToArray(), "application/pdf");
            } else {
                return this.RedirectToAction(c => c.Details(id));
            }
        }
        return this.RedirectToAction(c => c.Index(null, null));
    }
