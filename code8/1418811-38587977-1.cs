    public ActionResult MyData()
    {
        var data = true;
        return RedirectToAction("MyData2", new { foo = data });
    }
    
    public ActionResult MyData2(bool foo)
    {  
        var data = foo;
        return Content(data.ToString());
    }
