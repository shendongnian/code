    public string GetQueryString()
    {
        IDictionary<String, String> NavigationContextData = NavigationContext.QueryString;
        string data = "/Pagename.xaml?";
        foreach (var item in NavigationContextData)
        {
            data += item.Key + "=" + item.Value + "&";
        }
        data = data.Substring(0, data.Length - 1);
        return data;
    }
