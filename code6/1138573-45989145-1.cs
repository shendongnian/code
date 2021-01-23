    var rawurl = "https://emp.com/some/path?key1.name=a%20line%20with%3D&key2=val2&key2=valdouble&key3=&key%204=44#book1";
    var uri = new Uri(rawurl);
    Dictionary<string, string> queryString = ParseQueryString(uri.Query);
    
    // queryString return:
    // key1.name, a line with=
    // key2, valdouble
    // key3, 
    // key 4, 44
    
    public Dictionary<string, string> ParseQueryString(string requestQueryString)
    {
        Dictionary<string, string> rc = new Dictionary<string, string>();
        string[] ar1 = requestQueryString.Split(new char[] { '&', '?' });
        foreach (string row in ar1)
        {
            if (string.IsNullOrEmpty(row)) continue;
            int index = row.IndexOf('=');
            if (index < 0) continue;
            rc[Uri.UnescapeDataString(row.Substring(0, index))] = Uri.UnescapeDataString(row.Substring(index + 1)); // use Unescape only parts          
         }
         return rc;
    }
