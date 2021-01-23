    if (Page.IsPostBack)
    {
        if (Request.Form["btn"] != null)
        {
             //A btn was clicked, get it's value
             int btn = int.Parse(Request.Form["btn"]);
             //Do something with this btn number
        }
    }
