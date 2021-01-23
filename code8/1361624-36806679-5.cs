    @model ModelView
    ....
    @using (Html.BeginForm("Save_Definition"))
    {
        @Html.HiddenFor(m => m.ID)
        @Html.HiddenFor(m => m.IsOwner)
        @Html.CheckBoxFor(m => m.IsNameSelected )
        @Html.LabelFor(m => m.IsNameSelected )
        if (Model.IsOwner)
        {
            @Html.CheckBoxFor(m => m.IsPhoneSelected)
            @Html.LabelFor(m => m.IsPhoneSelected)
        }
        else
        {
            @Html.CheckBoxFor(m => m.IsAddressSelected)
            @Html.LabelFor(m => m.IsAddressSelected)
        }
        .... // submit buttons
    }
