     public PluginViewEngine()
            {
                PartialViewLocationFormats =
                    new[]
                    {     //themes
                          "~/Themes/{2}/Views/{1}/{0}.cshtml",                   
                         "~/Plugins/Yourpluginname/Views/{1}/{0}.cshtml"
                    };
    
                ViewLocationFormats =
                    new[]
                    {      
                         //themes
                          "~/Themes/{2}/Views/{1}/{0}.cshtml",
                         "~/Plugins/YourPluginName/Views/ShoppingCart/{0}.cshtml"
                    };
            }  
