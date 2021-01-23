    private void Button_Click(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            textBox1.Text = client.DownloadString("<your URL here>");
            textBox2.Text = client.DownloadString("<your URL here>");
            textBox3.Text = client.DownloadString("<your URL here>");
        }
    }
