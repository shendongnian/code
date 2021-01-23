    public ActionResult MyData()
    {
        var data = 123;
        return RedirectToAction("MyData2", new { id = data });
    }
    
    public ActionResult MyData2(int id)
    {  
        var data = id;
        return Content(data.ToString());
    }
