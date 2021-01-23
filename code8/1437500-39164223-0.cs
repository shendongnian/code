    var root = System.Web.Hosting.HostingEnvironment.MapPath("~/bin");
    var filePath = System.IO.Path.Combine(root, "One", "Two", "hi.txt");
    if(System.IO.File.Exists(filePath)) {
        var allText = System.IO.File.ReadAllText(filePath);
    }
