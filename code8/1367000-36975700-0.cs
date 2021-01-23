    foreach (string name in files)
    {
        string sourceFile = Server.MapPath( System.IO.Path.Combine("~/Content/Pdf", name));
        System.IO.File.Copy(sourceFile, Server.MapPath(System.IO.Path.Combine("~/Content/Temp", name)), true);
    }
