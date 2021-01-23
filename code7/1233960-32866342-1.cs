    string Commaseplist = D:\inetpub\wwwroot\app\public\015.pdfD:\inetpub\wwwroot\app\public\016.pdfD:\ine‌​tpub\wwwroot\app\public\017.pdfD:\inetpub\wwwroot\app\public\018.pdfD:\inetpub\ww‌​wroot\app\public\019.pdf
    string[] itemList =  Commaseplist.Replace(".pdf", ".pdf,").TrimEnd(',').split(',');
    
    foreach (string value in itemList)
    {
        mailMessagePlainText.Attachments.Add(new Attachment(value));
    }
