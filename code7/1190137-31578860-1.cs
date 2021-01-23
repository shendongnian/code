    @if (user.ExtendedProperties != null && user.ExtendedProperties.Count() > 0) {
        for (int i = 0; i < user.ExtendedProperties.Count(); i++)
        {
            @Html.DisplayFor(modelItem => user.ExtendedProperties[i].Name)
            @Html.DisplayFor(modelItem => user.ExtendedProperties[i].Value)
        }
    }
