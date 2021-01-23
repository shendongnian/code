    var news = new NewsPage();
    var article = new ArticlePage();
    var standard = new StandardPage();
    
    news as ArticlePage // works
    news as StandardPage // works
    news as object // works
    article as StandardPage // works
    article as object // works
    article as NewsPage // won't work
    standard as object // works
    standard as AriclePages // won't work
    standard as NewsPage // won't work
