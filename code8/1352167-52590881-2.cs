    private IEnumerator SendRequest(string url)
    {
      using (UnityWebRequest request = UnityWebRequest.Get(url))
      {
        yield return request.SendWebRequest();
    
        if (request.isNetworkError || request.isHttpError)
        {
          // handle failure
        }
        else
        {
          try
          {
            // entire file is returned via downloadHandler
            //string fileContents = request.downloadHandler.text;
            // or
            //byte[] fileContents = request.downloadHandler.data;
            
            // do whatever you need to do with the file contents
            if (loadAsset(fileContents))
              isAssetRead = true;
          }
          catch (Exception x)
          {
            // handle failure
          }
        }
      }
    }
