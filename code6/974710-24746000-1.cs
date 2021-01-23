    public async void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
        var query = from users in ParseObject.GetQuery("Users")
                    orderby users.CreatedAt ascending
                    select users ;
        IEnumerable<ParseObject> results = await query.FindAsync();
        foreach (var users in results)
        {
            TextBlock TextBlock = new TextBlock();
            var username = users.Get<string>("username");
               TextBlock.Text = "User: " + username.ToString();
               ContentStack.Children.Add(TextBlock);
        }
