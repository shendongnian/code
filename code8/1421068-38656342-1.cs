    @{
        string file = "~/Content/Images/" + User.Identity.GetUserId() + ".png";
        var imgUrl = string.Empty;
        if (File.Exists(file))
        { 
             imgUrl = Url.Content("~/Content/Images/" + User.Identity.GetUserId() + ".png") + "?time=" + DateTime.Now.ToString(); 
        }
        else
        { 
             imgUrl = Url.Content("~/Content/Images/Default_Profile.png") + "?time=" + DateTime.Now.ToString(); 
        }
        <img src="@imgUrl" height="50" width="50" />
    }
