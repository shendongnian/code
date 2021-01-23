    controller:
    
    public ActionResult DownloadTemplate()
    {
      //To Do
    }
    View:
    @using (Html.BeginForm("DownloadTemplate", "Controller", FormMethod.Post}))
        {
           <span class="leftalign">
           <input type="submit" id="btnBlankTemplate" class="k-button" value="Blank Template"/>
          </span>
        }
