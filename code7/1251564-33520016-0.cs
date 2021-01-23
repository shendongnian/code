    namespace NorthWindMVC.Views
    {
        public abstract class TestViewPage<TModel> : WebViewPage<TModel>
        {
            protected string TestProperty
            {
                get { return ViewData["TestProperty"] != null ? ViewData["TestProperty"].ToString() : String.Empty; }
                set { ViewData["TestProperty"] = value; }
            }
        }
        public abstract class TestViewPage : TestViewPage<dynamic>
        {
        }
    }
