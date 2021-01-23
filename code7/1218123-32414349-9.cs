    System.Web.HttpContext.Current.Response.Clear();
    System.Web.HttpContext.Current.Response.AddHeader("Content-Type", "binary/octet-stream");
    System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition",
                    "attachment; filename=" + fileName);  
    System.Web.HttpContext.Current.Response.TransmitFile(fileName);
