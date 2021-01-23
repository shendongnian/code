        if (speech.ToLower().Contains("search for")) // See if the string contains the 'search for' string.
        {
             string query = speech.Replace("search for", ""); // Remove the 'search for' text.
             // Old code (does not make the text fully URL safe)
             // query = query.Replace(' ', '+'); 
             query = System.Web.HttpUtility.UrlEncode(query);
             string url = "https://www.google.com.au/search?q=" + query;
             System.Diagnostics.Process.Start(url);
        }
