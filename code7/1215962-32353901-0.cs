    [WebMethod(EnableSession = true)]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public JsonResult GetCustomers()
    {
        DataTable dt = ICMS_DB_CLS.GetDataFromDB("Select * from  t_crm_customers");
        List<Customers> lis = new List<Customers>();
        lis = ExtensionList.ToListof<Customers>(dt);
        var toJson = new
             {
                 data = lis,
                 length = lis.Count
             };
        return Json(toJson, JsonRequestBehaviour.AllowGet);
    }
