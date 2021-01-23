    [AcceptVerbs("GET", "POST")]
    public string PostReggieHeader(string xml, string metaDataFlag)
    {
        string xmlData = string.Empty;
        bool metaTag = false;
        int metaTagInt = 0;
        bool isBool = false;
        if(metaDataFlag == null || bool.TryParse(metaDataFlag, out metaFlag))
        {
           isBool = true;
        }
        else 
        {
           int.TryParse(metaDataFlag, out metaTagInt);
        }
        //rest of code
    }
