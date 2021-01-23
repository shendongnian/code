    [HttpPost]
    public JsonResult Test(int Id)
    {
            var query = myDb.Responses
                  .Where(y => y.Id==Id).First();     
        return Json(new { Test= query.Name}, JsonRequestBehavior.AllowGet);
    }
