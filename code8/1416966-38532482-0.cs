    public JsonResult SecurityPermissionsTableData()
    {
       var lastItem = securityPermissionsTable
                    .Get(System.Security.Principal.WindowsIdentity.GetCurrent()
                    .Name.Split('\\').Last());
       return Json(lastItem , JsonRequestBehaviour.AllowGet);
    }
