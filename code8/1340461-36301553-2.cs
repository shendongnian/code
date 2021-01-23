    public static void Run(DbConnection connection)
    {
        var ad = new Advertisement
        {
            AdImages = new List<AdImage>
            {
                new AdImage {Image = "MyImage"}
            },
            Message = "MyMessage",
            Title = "MyTitle",
            User = new User()
        };
        using (Context context = new Context(connection))
        {
            context.Advertisements.Add(ad);
            context.SaveChanges();
        }
    }
