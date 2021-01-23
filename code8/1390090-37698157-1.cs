    List<dynamic> demo = new List<dynamic>();
    demo.Add(new { Name = "name1", Action = SomeAction.Read, Value = "someValue" });
    demo.Add(new { Name = "name1", Action = SomeAction.Restore, Value = "someValue" });
    demo.Add(new { Name = "name1", Action = SomeAction.Update, Value = "someValue" });
    
    demo = demo.OrderBy(e => (int)e.Action).ToList();
