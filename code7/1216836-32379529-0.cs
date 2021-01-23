    public void ReadPostedData()
    {
        Sender = HttpContext.Current.Request.Form["MailFormSubmitter_sender"];
        Subject = HttpContext.Current.Request.Form["MailFormSubmitter_subject"];        
        Message = HttpContext.Current.Request.Form["Message"];
        PdfMessage = HttpContext.Current.Request.Form["PdfMessage"];
    
        string IsCheckPDfMailSubmit = HttpContext.Current.Request.Form["IsCheckedPDFMailForm"];
        if (IsCheckPDfMailSubmit != null && IsCheckPDfMailSubmit.Length > 0)
        // A better option is to use string.IsNullOrEmpty:
        // if (!string.IsNullOrEmpty(IsCheckPDfMailSubmit))
        {
        IsCheckedPDFMailForm = IsCheckPDfMailSubmit.Equals("True", StringComparison.OrdinalIgnoreCase); 
    
    
    
    
    
        string v = HttpContext.Current.Request.Form["MailFormSubmitter_includeoverviewpdf"];
        IncludeOverviewPdf = v.Equals("true,false", StringComparison.Ordinal) ? true : false;
        // http://forums.asp.net/t/1314753.aspx
    
        ApplicantMailNodeSelectors[0] = HttpContext.Current.Request.Form["MailFormSubmitter_applicantemailaddress1"];
        ApplicantMailNodeSelectors[1] = HttpContext.Current.Request.Form["MailFormSubmitter_applicantemailaddress2"];
        ApplicantMailNodeSelectors[2] = HttpContext.Current.Request.Form["MailFormSubmitter_applicantemailaddress3"];
       }
    }
