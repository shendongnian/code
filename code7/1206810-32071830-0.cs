    using (var context = new  DatabaseContext())
    {
        var newTextual  = new Textuals { Number = 42, Content = "I iz kiddo" };
        context.Textuals.Attach(newTextual);
        context.SaveChanges();
    }
