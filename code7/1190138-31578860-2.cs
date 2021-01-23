    @for(int a = 0; a < Model.Count(); a++)
    {
        var user = Model[a];
        ...
        @if (user.ExtendedProperties != null
                && user.ExtendedProperties.Count() > 0) {
            for (int i = 0; i < user.ExtendedProperties.Count(); i++)
            {
                @Html.DisplayFor(m => m[a].ExtendedProperties[i].Name)
                @Html.DisplayFor(m => m[a].ExtendedProperties[i].Value)
            }
        }
    }
