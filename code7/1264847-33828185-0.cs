    public class Data
    {
         public int id { get; set; }
         public string BBBCode1 { get; set; }
         public string BBBCode2 { get; set; }
    }
    <div class="col-md-10">
            @Html.EditorFor(model => model.BBBCode1, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.BBBCode1, "", new { @class = "text-danger" })
    </div>
    <div class="col-md-10">
            @Html.EditorFor(model => model.BBBCode2, new { htmlAttributes = new { @class = "form-control" } })
            @Html.ValidationMessageFor(model => model.BBBCode2, "", new { @class = "text-danger" })
    </div>
