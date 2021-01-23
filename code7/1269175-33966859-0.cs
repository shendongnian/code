    public class MyNiceInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            var categoryList= new List<Category>();
    
            categoryList.Add(new Category() { Title= "Metal"});
            categoryList.Add(new Category() { Title= "Pop" });
    
            foreach (var category in categoryList)
                context.Categories.Add(category);
    
            base.Seed(context);
        }
    }
