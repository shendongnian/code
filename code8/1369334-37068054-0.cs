    public void SetPanelState(string state)
    {
      var panelCookie = HttpContext.Current.Response.Cookies["PanelState"];
      if (panelCookie == null)
      {
          panelCookie = new HttpCookie("PanelState") {Value = state};
          HttpContext.Current.Response.Cookies.Add(panelCookie);
      }
      else
      {
          HttpContext.Current.Response.Cookies["PanelState"].Value = state;
      }
    }
    [ScriptMethod(ResponseFormat = ResponseFormat.Json), WebMethod(EnableSession = true)]
    public void GetPanelState()
    {
       //It is here that you are reading the cookie.
       var panelCookie = HttpContext.Current.Request.Cookies["PanelState"];
       var data = new PanelState(){open = false};
       if (panelCookie == null || panelCookie.Value == null)
       {
          data.open = false;
       }
       else if (panelCookie.Value == "open")
       {
          data.open = true;
       }
       
       WriteOut(data);
    }
