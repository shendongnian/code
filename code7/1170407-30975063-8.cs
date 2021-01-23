    byte[] data;
    using (WebClient client = new WebClient())
    {
        data = client.DownloadData(x);
    }
    File.WriteAllBytes(saveToThisFolder + @"\" + (i++ + EndOfURL), data);
    counter++;
    workingURL.Text += x + System.Environment.NewLine;
