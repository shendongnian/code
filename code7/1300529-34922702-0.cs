    Public class StandardPage {
        public virtual string Title() { return "A standard page"; }
    }
    
    Public class ArticlePage : StandardPage {
        public override string Title() { return "An article page"; }
    }
    
    Public class NewsPage : ArticlePage {
        public override string Title() { return "A news page"; }
    }
