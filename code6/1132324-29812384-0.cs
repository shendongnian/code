    protected override void Seed(AllDb context)
    {
        List<Category> CategoryDefault = new List<Category> 
        {
            new Category { Name="Organic", UpID = 0 },
            new Category { Name="Object", UpID=0},
            new Category { Name="Time",UpID=0},
        };
        foreach (Category item in CategoryDefault)
        {
          context.Categories.Add(item);
          context.Users.Add(new User { Name = "sss" });
        }
        context.SaveChanges(); // make sure you save!
    }
