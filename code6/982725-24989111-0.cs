    public class MyViewModel
    {
        [Required]
        public string Field1 { get; set; }
        [Required]
        public string Field2 { get; set; }
    }
    
    ...
    
    @model MyViewModel
    
    @using (Html.BeginForm("MyAction", ...)
    {
        @Html.LabelFor(m => m.Field1)
        @Html.TextboxFor(m => m.Field1)
        <br />
        @Html.LabelFor(m => m.Field2)
        @Html.TextAreaFor(m => m.Field2)
        <button type="submit">Submit</button>
    }
    
    ...
    
    [HttpPost]
    public ActionResult MyAction(MyViewModel model)
    {
        if (!ModelState.IsValid)
             return MyGetAction(model);
        ...
    }
