    [HttpGet]
    public JsonResult GetComment(int ListID)
    {
        return Json(Mylist[ListID].Comment);
    }
