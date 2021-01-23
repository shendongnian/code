        public class SampleData : DropCreateDatabaseIfModelChanges<GetMedEntities>
        {
            protected override void Seed(GetMedEntities context)
            {
    //I STRICTLY RECOMMEND NOT TO PROVIDE CONTEXT AS A METHOD PARAMETER 
    //YOU HAVE TO WRITE PROPER DB LAYER TO DO SO
    
                context.Categories.AddRange( new List<Category>()
                {
                    new Category { Name = "Infections" },
                    new Category { Name = "Antibiotics" },
                    new Category { Name = "Vitamins" },
                    new Category { Name = "Cosmetics" }
                });
                context.SaveChanges();
            }
        }
