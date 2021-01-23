    try {
        // assuming asFinalLines is a string variable
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("Content-Length", asFinalLines.Length.ToString());
        Response.ContentType = "text/plain";
        response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
        Response.Write(asFinalLines);
    	response.Flush();
    } catch (Exception ex) {
        Debug.Print(asFinalLines);
    } finally {
    	HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
