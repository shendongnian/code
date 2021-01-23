    [HttpPost]
    public JsonResult Upload() 
    {
    foreach (var file in Request.Files)
    {
        if(file.ContentLength > 0)
        {
            file.SaveAs(Server.MapPath("~/Upload/" + file.FileName));
        }
     }
     return Json(new { result = true });
    }
    
