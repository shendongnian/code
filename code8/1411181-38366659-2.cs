    string getUTCTime()
    {
        System.Int32 unixTimestamp = (System.Int32)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
        return unixTimestamp.ToString();
    }
    
    private IEnumerator WaitForRequest()
    {
        string url = "API Link goes Here" + "?t=" + getUTCTime();
        WWW get = new WWW(url);
        yield return get;
        getreq = get.text;
        //check for errors
        if (get.error == null)
        {
            string json = @getreq;
            List<MyJSC> data = JsonConvert.DeserializeObject<List<MyJSC>>(json);
            int l = data.Count;
            text.text = "Data: " + data[l - 1].content;
        }
        else
        {
            Debug.Log("Error!-> " + get.error);
        }
    }
