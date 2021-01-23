    string path = Server.MapPath("~/XmlFiles/Cruisedata/product.xml");
    if (System.IO.File.Exists(path))
    {
       System.IO.File.Delete(path);
    }
