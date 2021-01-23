    @model FooViewModel
    @using (Html.BeginForm("Method", "Controller", FormMethod.Post, new { id = "form1" }))
    {
        @Html.LabelFor(x => Model.Distance)
        @Html.RadioButtonFor(x => Model.Far)
        @Html.RadioButtonFor(x => Model.Close)
        <button type="submit">Submit</button>
    }
    
    [HttpPost]
    public ActionResult Method(FooViewModel fooModel)
    {
        if (fooModel.Far){
           ViewData["Messages"] = MyMessageListHere;
        }
        else if (fooModel.Close){
           ViewData["Messages"] = MyMessageListHere;
        }
        return View();
    }
