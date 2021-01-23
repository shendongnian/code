    void SaveFunction(byte[]  bytes){
        string imageName = username + "_" + date + ".png";
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("file", bytes, imageName, "image/png");
        
        using (UnityWebRequest request = UnityWebRequest.Post("my url service", form))
        {
          
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Saved");
            }
        }
    }
