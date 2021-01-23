    public ActionResult GetPDF(int id) {
        // get the byte array for the PDF out of the database
        var Pdf = db.Invoices.FirstOrDefault(x => x.Id == id).Document;
        // return Pdf content
        return File(Pdf, "application/pdf");    
    }
