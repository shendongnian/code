    private void EditDatabase(Article article)
    {
        try
        {
            using (var db = new ArticleContext())
            {
                // assuming this "article" has been loaded from the database
                // by another context before, then you need to **ATTACH** it
                // to this current context before you can save it here!
                db.Articles.Attach(article);
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
            }
        }  
        catch(Exception exc)
        {
            // Log your exception
        }
    }
