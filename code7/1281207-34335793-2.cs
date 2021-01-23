    public class ProfilePage : BaseContentPage
    {
        private Label _lbltoken;
        public ProfilePage()
        {
            Appearing += (object s, EventArgs a) => {
               _lbltoken.Text = App.Token;
            };
            string tk = App.Token;
    
            _lbltoken = new Label()
            {
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = tk,
            };
            var stack = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = { _lbltoken },
            };
            Content = stack;
        }
    }
