     void Start()
     {
         try
         {
             //Do Something Dangerous
         }
         catch (Exception e)
         {
             //send log if Exception is thrown and caught
             sendLog(e);
         }
     }
    
     public void sendLog(Exception e)
     {
         string errorLogUrl = "http://yourServerUrl.com/gameName/log.php";
         WWWForm errorForm = new WWWForm();
    
         //Fill in Important Device Info
         errorForm.AddField("Device OS", SystemInfo.operatingSystem);
         errorForm.AddField("Device Model", SystemInfo.deviceModel);
         errorForm.AddField("Graphics Device Name", SystemInfo.graphicsDeviceName);
         errorForm.AddField("Graphics Device Vendor", SystemInfo.graphicsDeviceVendor);
         errorForm.AddField("Graphics Device Version", SystemInfo.graphicsDeviceVersion);
         errorForm.AddField("Graphics Memory Size", SystemInfo.graphicsMemorySize);
         errorForm.AddField("System Memory Size", SystemInfo.systemMemorySize);
    
         //Fill in current Scene
         errorForm.AddField("Current Scene", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    
         //Fill in Important Exception Info
         errorForm.AddField("Exc-StackTrace", e.StackTrace);
         errorForm.AddField("Exc-Source", e.Source);
         errorForm.AddField("Exc-Message", e.Message);
    
         //FileName
         errorForm.AddField("File Name", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss" + UnityEngine.Random.Range(1, 900000)));
    
         WWW www = new WWW(errorLogUrl, errorForm);
         StartCoroutine(WaitForRequest(www));
     }
    
     private IEnumerator WaitForRequest(WWW www)
     {
         yield return www;
    
         //Check if we failed to send
         if (www.error != null)
         {
             //Failed To Send.
         }
     }
