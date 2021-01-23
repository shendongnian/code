    var pdfFileName = "Some Filename";
    
    if (Request.Browser.Browser == "InternetExplorer" || Request.Browser.Browser == "IE")
    {
    	Response.AppendHeader("content-disposition", @"attachment;filename=""" + pdfFileName + @".pdf""");
    }
    else
    {
    	Response.AppendHeader("content-disposition", @"inline;filename=""" + pdfFileName + @".pdf""");
    }
    
    byte[] pdfBytes = ... // get the file data into this variable
    return File(pdfBytes, "application/pdf")
