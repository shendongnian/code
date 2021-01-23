    [HttpGet]
    public JsonResult GetSectors()
    {
        Sector[] sectors = sectorManager.GetSectorsForUser("cn873284").ToArray();
        return Json(sectors, JsonRequestBehavior.AllowGet);
    }
