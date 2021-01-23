    var bytes = client.DownloadData(webUrl); <-- NOT null
    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
    {
     ...  img.StreamSource = new MemoryStream(bytes); <-- null
     ...
    }
    bytes = null; // something like this - because why not? 
