    // Code copied from linked blog
    static void Main(string[] args)
    {
        Database.SetInitializer(new DropCreateDatabaseAlways<BlogContext>());
        using (var db = new BlogContext()) //initializer won't be called here
        {
            ...
            db.Categories.Add(cat); //initializer will be called here
            db.BlogPosts.Add(post);
            ...
        }
        Console.ReadLine();
    }
