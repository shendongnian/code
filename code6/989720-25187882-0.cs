    @{
        var choices = ViewData["choices"] as IEnumerable<SelectListItem> ?? new List<SelectListItem>();
        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(ViewData.ModelMetadata.ModelType) && ViewData.ModelMetadata.ModelType != typeof(string))
        {
            @Html.ListBox("", choices)
        }
        else
        {
            @Html.DropDownList("", choices)
        }
    }
