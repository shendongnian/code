    Application.CaptureScreenshot is not for WebGL..
    
    WebGL must use read pixel.
    
    Guess you trying to export some files from WebGL, then should use .php or something else. Beacause WebGL requires stp connection.
    
    
    IEnumerator SendImagetophp()
    {
            //Path to PHP
            string screenShotURL = "http://youtphppath/yourphpname.php";
    
    
            //Wait until frame ends
            yield return new WaitForEndOfFrame();
    
            // Create a texture the size of the screen, RGB24 format
            int width = Screen.width;
            int height = Screen.height;
            tex = new Texture2D(width, height, TextureFormat.RGB24, false);
    
            // Read screen contents into the texture        
            tex.ReadPixels(new Rect(0,0, width, height), 0, 0, false);
            tex.Apply();
            
    
            // Encode texture into PNG
            byte[] bytes = tex.EncodeToPNG();
            Destroy(tex);
    
            // Create a Web Form
            WWWForm form = new WWWForm();
            form.AddField("frameCount", Time.frameCount.ToString());
            //form.AddField("email", userEmailAddress);
            form.AddBinaryData("file", bytes, userEmailAddress + "_screenShot.png", "multipart/form-data");//"image/png"
    
            // Post WWWForm to path
            UnityWebRequest www = UnityWebRequest.Post(screenShotURL, form);
    
            yield return www.SendWebRequest();
            //Debug
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Image Uploaded!");
            }`enter code here`
    }
