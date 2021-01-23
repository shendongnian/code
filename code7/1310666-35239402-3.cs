    public class MyView
        : Xamarin.Forms.View
    {
        public static readonly BindableProperty MyHtmlProperty = BindableProperty.Create<MyView, string>(p => p.MyHtml, default(string));
        public string MyHtml
        {
            get { return (string)GetValue(MyHtmlProperty); }
            set { SetValue(MyHtmlProperty, value); }
        }
    }
