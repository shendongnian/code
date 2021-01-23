    public MyWindow()
    {
        InitializeComponent();
      	myMediaElement.Source = new Uri(@"C:\video\a.mpg", UriKind.Absolute);
    }
    
    private void ChangeMedia(object sender, MouseButtonEventArgs args)
    {
     	MessageBox.Show("Media to be changed");// This is called and a message box pops up showing this message.
     	myMediaElement.Source = new Uri(@"C:\video\b.mpg", UriKind.Absolute);
     	MessageBox.Show("Media changed successfully"); // never gets called and message box does not pop up 
    }
