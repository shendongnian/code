    @model yourViewModelAssembly.CustomerVM
    ....
    
    @using (Html.BeginForm("DisplayResult", "DisplayCustomer", FormMethod.Post))
    {
        @Html.AntiForgeryToken();
        @Html.ValidationSummary(true);
        @Html.LabelFor(m => m.Id)
        @Html.TextBoxFor(m => m.Id)
        @Html.ValidationMessageFor(m => m.Id)
        @Html.LabelFor(m => m.Code)
        @Html.TextBoxFor(m => m.Code)
        @Html.ValidationMessageFor(m => m.Code)
        ....
    }
