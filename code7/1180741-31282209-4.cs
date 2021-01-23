    interface IExpressionable {
        string GetExpressionOne();
        string GetExpressionTwo();
    }
    class Genre : IExpressionable {
        string Language {get;set;}
        string Name {get;set;}
        public string GetExpressionOne() {
            return Language;
        }
        public string GetExpressionOne() {
            return Name;
        }
    }
    class SomethingElse {
        string Orange {get;set;}
        string BananaPeel {get;set;}
        public string GetExpressionOne() {
            return Orange;
        }
        public string GetExpressionOne() {
            return BananaPeel;
        }
    }
    Genre genre = new Genre();
    SomethingElse else = new SomethingElse();
    Expression<Func<IExpressionable, bool>> expression = CreateExpression(genre, lang, name);
    Expression<Func<IExpressionable, bool>> expression2 = CreateExpression(else, lang, name);
    expression = (g => g.GetExpressionOne() == "en" && g.GetExpressionTwo() == "comedy");
