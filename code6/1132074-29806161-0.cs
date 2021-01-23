    public class Movie
    {
       public virtual ObservableCollection<Category> Categories { get; set; }
    
       public void AddCategory(string name)
       {
           using (var dbContext = new MyDbContext())
           {
               // get the movie object from dbContext so that it is attached
               var movie = dbContext.Movies.SingleOrDefault(m => m.Name == Name); // or match Movie by Id instead of Name
               var category = dbContext.Categories.SingleOrDefault(x => x.Name == name) ?? new Category(name);
               movie.Categories.Add(category);
               dbContext.SaveChanges();
           }
       }
    }
