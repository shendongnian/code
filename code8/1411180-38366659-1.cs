    IEnumerator WaitForRequest(string url)
    {
    
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Cache-Control", "max-age=0, no-cache, no-store");
        www.SetRequestHeader("Pragma", "no-cache");
    
        yield return www.Send();
        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Received " + www.downloadHandler.text);
        }
    }
