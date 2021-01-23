    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    namespace App1
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                AddText("hello");
                RemoveText("2");
                AddText("Goodbye");
                RemoveText("hello");
                RemoveText("1");
            }
            private void AddText(string text)
            {
                TextBox tb = new TextBox();
                tb.Text = text;
                NumbersGrid.Children.Add(tb);
            }
            private void RemoveText(string text)
            {
                foreach(UIElement child in NumbersGrid.Children)
                {
                    TextBox tb = (TextBox)child;
                    if (tb.Text.Equals(text))
                    {
                        NumbersGrid.Children.Remove(tb);
                    }
                }
            }
        }
    }
