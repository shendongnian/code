    @model DepenInjectionINMVC5App.Controllers.DemoController.EventBooking
        @{
            ViewBag.Title = "CreateDDL";
            Layout = "~/Views/Shared/_Layout.cshtml";
        }
    
        <h2>CreateDDL</h2>
    
    
        <div>
            @Html.LabelFor(Model => Model.Id, "Event", new { @class = "control-label" })
            @Html.DropDownListFor(Model => Model.Id, new SelectList(ViewBag.EventList, "Id", "Name"))
        </div>
