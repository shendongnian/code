    private void SendJson(string url, string json)
    {
        StartCoroutine(PostRequestCoroutine(url, json, callback));
    }
        
    private IEnumerator PostRequestCoroutine(string url, string json)
    {
        var jsonBinary = System.Text.Encoding.UTF8.GetBytes(json);    
    
        DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();
        
        UploadHandlerRaw uploadHandlerRaw = new UploadHandlerRaw(jsonBinary);
        uploadHandlerRaw.contentType = "application/json";
        
        UnityWebRequest www = 
            new UnityWebRequest(url, "POST", downloadHandlerBuffer, uploadHandlerRaw);
        
        yield return www.SendWebRequest();
    
        if (www.isNetworkError)
            Debug.LogError(string.Format("{0}: {1}", www.url, www.error));
        else
           Debug.Log(string.Format("Response: {0}", www.downloadHandler.text));
    }
