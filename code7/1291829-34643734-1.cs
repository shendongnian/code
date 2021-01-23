    // generating link without parameters - /Home/Index
    urlHelper.Action<HomeController>(c => c.Index());
    
    // generating link with parameters - /Home/Index/1
    urlHelper.Action<HomeController>(c => c.Index(1));
    
    // generating link with additional route values - /Home/Index/1?key=value
    urlHelper.Action<HomeController>(c => c.Index(1), new { key = "value" });
    
    // generating link where action needs parameters to be compiled, but you do not want to pass them - /Home/Index
    // * With.No<TParameter>() is just expressive sugar, you can pass 'null' for reference types but it looks ugly
    urlHelper.Action<HomeController>(c => c.Index(With.No<int>()));
