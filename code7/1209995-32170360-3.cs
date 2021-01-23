    public class SampleData 
    {
      public void SeedSampleData() 
      {
        var context = new GedMedEntities();
        context.Categories.AddRange( new List<Category>()
        {
          new Category { Name = "Infections" },
          new Category { Name = "Antibiotics" },
          new Category { Name = "Vitamins" },
          new Category { Name = "Cosmetics" }
        });
        context.SaveChanges();
