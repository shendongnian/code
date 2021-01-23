    @model FooViewModel
    @using (Html.BeginForm("Method", "Controller", FormMethod.Post, new { id = "form1" }))
    {
        @Html.RadioButtonFor(x => Model.Distance)
        <button type="submit">Submit</button>
    }
    
    [HttpPost]
    public ActionResult Method(FooViewModel fooModel)
    {
        if (fooModel.Distance == "far"){
           ViewData["Messages"] = MyMessageListHere;
        }
        else if (fooModel.Distance == "close"){
           ViewData["Messages"] = MyMessageListHere;
        }
        return View();
    }
