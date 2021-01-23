    // generate you file
    // set FilePath and FileName variables
    string stFile = FilePath + FileName;
    try {
        response.Clear();
        response.ContentType = "text/plain";
        response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
        response.TransmitFile(stFile);
    	response.Flush();
    } catch (Exception ex) {
        // any error handling mechanism
    } finally {
    	if (System.IO.File.Exists(stFile)) {
            System.IO.File.Delete(stFile);
    	}
    	HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
