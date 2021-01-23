    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App1
    {
        public sealed partial class ContentDialog1 : ContentDialog
        {
            public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
                "Text", typeof (string), typeof (ContentDialog1), new PropertyMetadata(default(string)));
    
            public ContentDialog1()
            {
                InitializeComponent();
            }
    
            public string Text
            {
                get { return (string) GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
    
            private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
            {
            }
    
            private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
            {
            }
        }
    }
