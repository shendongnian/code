    public ActionResult AddTechNote(TicketView ticketReturn, string Note, bool PublicNote, HttpPostedFileBase fileToUpload, string CopyIntoEmail)
    {
            string _fileName = null;
    
            if (fileToUpload != null && fileToUpload.ContentLength > 0)
            {
                   _fileName = new FileController().UploadFile(fileToUpload, "Tickets", ticketReturn.TicketNumber.ToString());
            }
      ...........
    }
