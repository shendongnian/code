    if(Session["MyArticle"] != null)
    {
        // The key MyArticle exists, so it is safe to attempt to get the object value
        var myArticleFromSession = Session["MyArticle"] as Article;
        
        // Since we used as to attempt the cast, 
        // then myArticleFromSession will be null if the cast failed 
        // so check for null before using myArticleFromSession
        if(myArticleFromSession != null)
        {
            // Use myArticleFromSession here
        }
    }
