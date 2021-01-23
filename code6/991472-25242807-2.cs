    [HttpPost]
    public ActionResult DeleteBeacon(object beaconid, object instid, int pageno)
    {
        Response.StatusCode = 500;
        return Json(new { result = "Hello" });
    }
