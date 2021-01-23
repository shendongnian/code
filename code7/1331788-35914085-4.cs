    @using WebApplication1.Misc
    @using WebApplication1.Models
    @{
        ViewBag.Title = "Test";
    }
    
    <h2>Index</h2>
    
    @* No model *@
    @Html.RazorEncode("<p>Paragraph output</p>")
    @* String model *@
    @Html.RazorEncode("<p>Using a @Model</p>", "string model" )
    @* Loop, just to try it out *@
    @Html.RazorEncode("@for (int i = 0; i < 100; ++i) { <p>@i</p> }")
    @* Calling ActionLink with a typed model *@
    @Html.RazorEncode("@Html.ActionLink(Model.Text, Model.Action)", new TestModel { Text = "Foo", Action = "Bar" })
