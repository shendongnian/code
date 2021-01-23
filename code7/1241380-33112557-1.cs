    public sealed class InitialiseWebBrowser : Behavior<MyVM>
    {
        public IQueryHandler<Query.Html, string> HtmlQueryHandler { private get; set; }
        // ...
    }
