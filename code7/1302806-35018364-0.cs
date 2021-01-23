    using (var form = Html.Bootstrap().Form().SetHorizontal().Begin())
    {
        @form.InputFor(m => m.Id).SetReadonly().SetLg(3)
        @form.SelectFor(m => m.CountryId, Model.CountryList).SetLg(3)
        using (var formGroup = form.FormGroup().SetAutoColumns(false).Begin())
        {
            @form.ControlLabel(m => m.Name).SetMd(4)
            @form.InputFor(m => m.Name).SetControlLabel(null).SetLg(2)
            using (Html.Bootstrap().GridColumn().SetLg(1).Begin())
            {
                @Html.Bootstrap().Button().SetIcon(Icon.Film)
            }
        }
    }
