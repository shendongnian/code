    public ActionResult RenderViewToString()
    {
        string html = "this is your view string";
    
        // Push it to a View
        ViewBag.RenderedHtml = html;
        
        return View();
    }
