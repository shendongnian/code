    interface IExpressionable {
        string Language { get;set; }
        string Name { get;set; }
    }
    class Genre : IExpressionable {
        string Language {get;set;}
        string Name {get;set;}
    }
    Genre genre = new Genre();
    Expression<Func<IExpressionable, bool>> expression = CreateExpression(genre, lang, name);
    expression = (g => g.Language == "en" && g.Name == "comedy")
