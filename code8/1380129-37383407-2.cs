    class FacebookInfo
    {
        public string request;
        public string[] to;
    }
    
    void Start()
    {
        FacebookInfo fbInfo = new FacebookInfo();
        string fbJson = "{\"request\": \"420211088059698\",\"to\": [\"100002669403922\",\"100000048490273\"]}";
        fbInfo = JsonUtility.FromJson<FacebookInfo>(fbJson);
    
        //Show request
        Debug.Log("Request: " + fbInfo.request);
    
        //Show to arrays
        for (int i = 0; i < fbInfo.to.Length; i++)
        {
            Debug.Log("To : " + fbInfo.to[i]);
        }
    }
