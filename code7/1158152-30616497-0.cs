    @using (Html.BeginForm()) {
    HtmlHelper.ClientValidationEnabled = true;
    HtmlHelper.UnobtrusiveJavaScriptEnabled = true; 
    @Html.ValidationSummary()
     @Html.LabelFor(m => m.Name)
     @Html.TextBoxFor(m => m.Name)
     @Html.ValidationMessageFor(m => m.Name)
     
    }
    
    @section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
