        var tempFileVirtualPath = $"/App_Data/Temp/{Guid.NewGuid()}.css"        
        System.IO.File.WriteAllText(Server.MapPath(tempFileVirtualPath), initialCssContent);
        var autoprefixer = new AutoprefixCssPostProcessor();
        var content = autoprefixer.PostProcess(new Asset(tempFileVirtualPath)).Content;
        var absolutePath = "C:\somewhere\style.css";
        System.IO.File.WriteAllText(absolutePath, content);
