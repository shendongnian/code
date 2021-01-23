    @model MainVM 
    ....
    @for (var i = 0; i < Model.Days.Count; i++)
    {
      @Html.RadioButtonFor(m => m.SelectedDay, Model.Days[i].DeliveryDay, new { id = "" })
      @Html.DisplayFor(m => m.Days[i].DeliveryType)
      @Html.HiddenFor(m => m.Days[i].DeliveryType)
      ....
    }
