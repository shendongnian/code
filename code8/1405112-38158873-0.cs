    private void EditDatabase(Article article)
    {
        try
        {
            using (var db = new ArticleContext())
            {
                // assuming you're *created* that "article" from scratch  
                // then you need to **ADD** it to the context first, to save it!
                db.Articles.Add(article);
                // this won't be needed
                // db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
            }
        }  
        catch(Exception exc)
        {
            // Log your exception
        }
    }
