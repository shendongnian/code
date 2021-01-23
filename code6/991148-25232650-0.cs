    private async void BMP_MessageReceivedFromForeground(object sender, MediaPlayerDataReceivedEventArgs e)
    {
        foreach (string key in e.Data.Keys)
        {
            switch (key)
            {
                case "SetTrack":
                    string passedPath = (string)e.Data.Values.FirstOrDefault();
                    //here code you want to perform - change track/stop other 
                    // that depends on your needs
                    break;
         // rest of the code
