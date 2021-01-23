    @if (Model.ExtendedProperties != null && Model.ExtendedProperties.Count() > 0) {
        for (int i = 0; i < Model.ExtendedProperties.Count(); i++)
        {
            @Html.DisplayFor(x => Model.ExtendedProperties[i].Name)
            @Html.DisplayFor(x => Model.ExtendedProperties[i].Value)
        }
    }
