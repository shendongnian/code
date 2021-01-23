        long sz = objFileInfo.Length;
        Response.ClearContent();
        Response.AddHeader("Content-Disposition", 
        string.Format("attachment; filename = {0}",System.IO.Path.GetFileName(objFileInfo)));
        Response.AddHeader("Content-Length", sz.ToString("F0"));
        Response.TransmitFile(objFileInfo);
        Response.End();
