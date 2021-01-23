    @model MvcMovie.Models.Movie
    @{
    ViewBag.Title = "Create";
    }
    @using (Html.BeginForm("controllerName","ActionName",FormMethod.Post)) 
    {
    @Html.ValidationSummary(true)
    <fieldset>
        <legend>Movie</legend>
        <div class="editor-label">
            @Html.TextBox("Name",null,New {id="Name"})
        </div>
    <div class="editor-label">
            <input type="submit" value="save" />
        </div>
    </fieldset>
    }
    In controller,
    [HttpPost]
    Public ActionResult MethodName(FormCollection form)
    {
    string name = form["Name"];
    // name contains your textbox value
    }
