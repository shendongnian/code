    //async to not freeze the UI
    private async void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Ping pingSender = new Ping();
        var tb = (TextBox)sender;
        
        //a little regex to check if the texbox contains a valid ip adress (ipv4 only)
        Regex rgx = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
        if (rgx.IsMatch(tb.Text))
        {
            int timeout = 120;
            try
            {
                var reply = await pingSender.SendPingAsync(tb.Text, timeout);
                textBlock.Text = reply.Status == IPStatus.Success ? "OK" : "KO";
            }          
            catch (Exception ex) when (ex is TimeoutException || ex is PingException)
            {
                textBlock.Text = "KO";
            }
        }
        else
        {
            if (textBlock != null)
            {
                textBlock.Text = "Not valid ip";
            }
        }
    }
