    public ActionResult DoDynamic()
    {
        //Some data to use only for this sample (you already have some data to query, so you don't need this)
        var data = new List<DummyData>
        {
            new DummyData {Name = "Foo is my name", InstructorId = "Foo 1", Invoice = 1},
            new DummyData {Name = "Bar is my name", InstructorId = "Bar 1", Invoice = 2},
            new DummyData {Name = "Hello is my name", InstructorId = "Foo 2", Invoice = 1},
        };
            
        var query = data.Where(o => o.Invoice == 1).GroupBy(row => new { row.InstructorId }).Select(group => new { name = group.Key.InstructorId }).ToList();
        //Yeah, we can do dynamic :)
        dynamic foo = new ExpandoObject();
        foo.bar = "Hello from dynamic object";
        if (query.Any())
        {
            var result = "";
            query.ForEach(i => result += i.name + "<br />");
            foo.dyn = result;
        }
        //Lets use ViewBag
        ViewBag.SomeObject = foo;
        //And let's use model too...
        return View(foo);
    }
