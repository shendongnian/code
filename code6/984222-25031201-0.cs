    public JsonResult directory()
    {
        return Json(this.GetAlphaa(), JsonRequestBehavior.AllowGet);
    }
    private List<directories> GetAlphaa()
    {
        ... // your original code
    }
