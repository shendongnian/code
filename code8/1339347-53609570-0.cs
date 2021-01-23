    public enum EventType
    {
    [Display(Name = "Option 1")]
    Option1,
    [Display(Name = "Option 2")]
    Option2,
    [Display(Name = "Option 3")]
    Option3
    }
    @Html.EnumDropDownListFor(model => model.EventType,      
                  new {@id = "eventType", @class = "form-control"  })
