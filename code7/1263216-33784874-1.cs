    private void btnView_Click(object sender, RoutedEventArgs e)
     {
         string s = txtNameFind.Text;
         this.Content = new Page1(s);
     }
    public Page1(string s)
    {
        this.InitializeComponent();
        LoadData(s);
    }  
    private async void LoadData(string s)
    {
        var client = new ServiceReference1.Service1Client();
        var res = await client.FindInfoAsync(s);
        listBox.ItemsSource = res;
    }
