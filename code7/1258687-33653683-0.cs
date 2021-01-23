    using (SaveFileDialog sfd = new SaveFileDialog())
    {
        // This only allows you to choose PNG, you may want to change it.
        sfd.Filter = "Image Files (*.png)|*.png";
        DialogResult result = sfd.ShowDialog();
        if (result == DialogResult.OK)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("User-Agent: Other");
                wc.DownloadFile("http://www.weather.gov/images/dlh/WxStory/FileL.png?", sfd.FileName);
             }
         }
     }
