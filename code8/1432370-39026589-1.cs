    @{
   
      var stateId = Request.QueryString["ddlStates"] as string;
      List<States> aux = Fill.GiveMeStates();
      SelectList states = new SelectList(aux, "StateID", "Name");
      List<SelectListItem> cities = new List<SelectListItem>();
      if (!String.IsNullOrEmpty(stateId))
      {       
        var state = aux.FirstOrDefault(f => f.StateID == Convert.ToInt32(stateId));
        if (state != null)
        {
            cities = state.Cities
                          .Select(x => new SelectListItem {Value = x, Text = x}).ToList();
        }
      }
    }
    <label>Select a state and hit submit </label>
    @using (Html.BeginForm("Index", "Home", FormMethod.Get)) 
    {
      @Html.DropDownList("ddlStates", states)
      <label>Cities < /label>
      @Html.DropDownList("City", cities)
      <input type="submit" />
    }
