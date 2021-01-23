    string url = "WEBSITE.php";
    string content = WebClient.DownloadString(url);
    foreach (string line in content.Split(new string[] { "<br>", "</br>" }, StringSplitOptions.None))
    {
        // Do something with each "line" ;-)
    }
