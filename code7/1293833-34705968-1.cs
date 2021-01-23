    // Store the URL of the website you are looking at.
    string path = "http://euw.op.gg/summoner/userName=";
    string userName = "froggen";
    string url = path + userName;
    // Create a new WebClient to download the html page.
    using (WebClient client = new WebClient())
    {
        // Download the html source code of the user page.
        string html = client.DownloadString(url);
    
        // Finding the kda depends on the website - you need to know what you are looking for. Have a look at the page source and see where the kda is stored.
        // I've had a look at the source of my example and I know kda is stored in <span class="KDARatio">3.92:1</span>.
    
        // You'll need a way to get that data out of the HTML - you might try to parse the file and traverse it.
        // I've chosen Regex to match the data I'm looking for.
        string pattern = @"<span class=""KDARatio"">\d+\.\d+";
        // I take the first string that matches my regex from the document.
        string kdaString = Regex.Matches(html, pattern)[0].Value;
        // I trim the data I don't need from it.
        string substring = kdaString.Substring(kdaString.IndexOf('>') + 1);
        // Then I can convert it into a double - giving me the x:1 kda ratio for this player.
        double kda = double.Parse(substring);
    };
