    @for (int i = 0; i < Model.CustomPropeties.Count(); i++)
    {
        @Html.HiddenFor(x => Model.CustomProperties[i].Filter
        @Html.DropdownListFor(x => Model.CustomProperties[i].SelectedValue,
            Model.CustomProperties[i].SelectList)
    }
