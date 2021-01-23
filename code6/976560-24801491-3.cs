    public MainPage()
    {
       this.InitializeComponent();
       myTextBox.TextChanged += (sender, e) => hyperText.Text = myTextBox.Text;
    }
    private async void myhyperlink_Click(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
    {
      await Windows.System.Launcher.LaunchUriAsync(new Uri(@"http://" + myTextBox.Text));
    }
