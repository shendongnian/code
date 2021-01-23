     IEnumerator screenShotCoroutine()
    {
        yield return new WaitForEndOfFrame();
        string path = Application.persistentDataPath + "/DrukaloScreenshot.png";
    
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
    
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    
        //Wait for a long time
        for (int i = 0; i < 15; i++)
        {
            yield return null;
        }
    
        screenImage.Apply();
    
        //Wait for a long time
        for (int i = 0; i < 15; i++)
        {
            yield return null;
        }
    
        //Convert to png(Expensive)
        byte[] imageBytes = screenImage.EncodeToPNG();
    
        //Wait for a long time
        for (int i = 0; i < 15; i++)
        {
            yield return null;
        }
    
        //Create new thread then save image to file
        new System.Threading.Thread(() =>
        {
            System.Threading.Thread.Sleep(100);
            File.WriteAllBytes(path, imageBytes);
        }).Start();
    }
