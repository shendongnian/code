    //SERVER
      public ActionResult AdminMenu()
      {
          var am = _amr.GetAdminMenu();
          return Json(am,JsonBehaviour.AllowGet);
      }
  
      //CLIENT
        @using (Ajax.BeginForm("AdminMenu","AdminController", null,  
            new AjaxOptions
            {
                OnSuccess = "renderSuccess",
                OnFailure = "renderFailure",
                OnBegin = "renderBegin"
            },
            new
            {
                id = "frmViewerAdminMenu",
                name = "frmViewerAdminMenu"
            })
        )
        {
        ...
    
            <script type="text/javascript">
                function renderSuccess(ajaxContext){
                   /// ajaxContext is whatever comes back from GetAdminMenu()
                }
            </script>
         ...
        }
