    private async void buttonGetHTML_Click(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            string context = await client.DownloadStringAsync(textBoxUrl.Text);
            htmlContent.Text = content
        }
    }
Most people try to solve this with Control.Invoke or something (see link in comment) but in this case there is a better option. Using the Async methods of the WebClient class. See https://msdn.microsoft.com/en-us/library/system.net.webclient.downloadstringasync(v=vs.110).aspx
