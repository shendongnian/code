    public JsonResult ActionName(int? id)
        {
            string Data = "Sample Data";
            return Json(Data, JsonRequestBehavior.AllowGet);
        }
