    md.Title = "Title";
    md.TableDt.Add(new TableData { Name = "name1" });
    md.TableDt.Add(new TableData { Name = "name2" });
    RazorMachine rm = new RazorMachine();
    ITemplate template = rm.ExecuteContent(
        @"Razor says:@@ok Hello @Model.FirstName  @Model.LastName
          @foreach (var v in Model.TableDt)
          {
              @v.Name
          }
    ",
      new { FirstName = "John", LastName = "Smith" });
    Console.WriteLine(template.Result);
