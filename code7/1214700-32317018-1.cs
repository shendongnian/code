    [HttpPost]
    public JsonResult Opticians(Guid? Id)
    {
        var opticianList = db.Opticians.Where(a => a.PracticeId == Id).Select(a => a.User).ToList();
        return Json(opticianList);
    }
