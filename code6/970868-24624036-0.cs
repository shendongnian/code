    Page1.xaml.cs
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                NavigationService.Navigate(new Uri("/Page2.xaml?myNumber=" + TextBox1.Text, UriKind.Relative));
            }
    
    Page2.xaml.cs
    
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                string QueryStr = "";
                NavigationContext.QueryString.TryGetValue("myNumber",out QueryStr);
                TextBlock1.text = ((int.Parse(QueryStr)) / 2).ToString();
    	}
