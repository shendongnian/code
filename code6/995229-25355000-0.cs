    public class EmployeeList
    {
        public List<Employee> ListOfEmployees { get; set; }
    }
    [HttpPost]
    public ActionResult Index([Bind(Prefix = "ListOfEmployees")]EmployeeList employeeList1)
    {
        .......
    }
    @model test.Models.EmployeeList
    @{
        ViewBag.Title = "Index";
     }
    
    <h2>Index</h2>
    
    @using (Html.BeginForm("Index", "Home", FormMethod.Post, new { @id = "testForm" }))
    {
        @Html.LabelFor(m => m.eid)
        @Html.EditorFor(m => m.eid)
        @Html.HiddenFor(m => m.eid)
        <br />
        @Html.EditorFor(x => x.ListOfEmployees)
        <br />
        <p>
            <input type="submit" value="Post" />
        </p>
    }
