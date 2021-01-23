    @model WebApplication1.Controllers.Person
    @using WebApplication1.Controllers;
    
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    
    @using (Html.BeginForm("CreatePersonPost", "Sale"))
    {
        @Html.EditorFor(m => m.PersonEmail)
    
        @Html.RadioButtonFor(m => m.Gender, GenderType.Male) @GenderType.Male.ToString()
        @Html.RadioButtonFor(m => m.Gender, GenderType.Female) @GenderType.Female.ToString()
        @Html.ValidationMessageFor(m => m.Gender)
    
        <input type="submit" value="click" />
    }
