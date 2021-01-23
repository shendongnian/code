    public ActionResult CheckLocation(int Location)
        {
            var city = getLocation(Location);
            if (city != null)
            {
                // city is string type, example: string city="Mumbai";
                return Json(new {Status=true, City = city}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Status=false, City=""}, JsonRequestBehavior.AllowGet);
        }
