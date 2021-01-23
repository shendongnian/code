    @using MyFirstWebApplication.Models
    @model IEnumerable<MyFirstWebApplication.Models.Student>
    @{
        ViewBag.Title = "Title";
    }
    
    <h2>This is a heading</h2>
    
    @foreach (Student student in Model)
    {
        <h2>Student Name: @student.FirstName @student.LastName</h2>
    }
    
