    public JsonResult SecurityPermissionsTableData()
    {
       var permissionList = securityPermissionsTable
                    .Get(System.Security.Principal.WindowsIdentity.GetCurrent()
                    .Name.Split('\\').Last());
       return Json(permissionList , JsonRequestBehaviour.AllowGet);
    }
