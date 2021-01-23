    private void newmail_Click(object sender, RoutedEventArgs e)
    {
        Nieuweemail _nieuweEmail = new Nieuweemail(_username);
        _nieuweEmail.Closed += SetContentHandler;
        _nieuweEmail.Show();
    }
    private void SetContentHandler(object sender, EventArgs e)
    {
        setContent();
    }
