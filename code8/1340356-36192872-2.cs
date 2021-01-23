    IEnumerator screenShotCoroutine()
    {
        string path = Application.persistentDataPath + "/DrukaloScreenshot.t2D";
        string newPath = Application.persistentDataPath + "/DrukaloScreenshot.png";
    
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
    
        byte[] rawData = null;
    
        //Create new thread then Load image
        new System.Threading.Thread(() =>
        {
            System.Threading.Thread.Sleep(100);
            rawData = File.ReadAllBytes(path);
        }).Start();
    
        //Wait for a long time
        for (int i = 0; i < 9; i++)
        {
            yield return null;
        }
    
        //Put loaded bytes to Texture2D 
        screenImage.LoadRawTextureData(rawData);
    
        //Wait for a long time
        for (int i = 0; i < 9; i++)
        {
            yield return null;
        }
    
        screenImage.Apply();
    
        //Wait for a long time
        for (int i = 0; i < 9; i++)
        {
            yield return null;
        }
    
        //convert to png
        byte[] pngByte = screenImage.EncodeToPNG();
    
        //Wait for a long time
        for (int i = 0; i < 9; i++)
        {
            yield return null;
        }
    
        //Do whatever you want with the png file(display to screen or save as png)
    
    
        //Create new thread and Save the new png file, then Delete Old image(DrukaloScreenshot.t2D)
        new System.Threading.Thread(() =>
        {
            System.Threading.Thread.Sleep(100);
            File.WriteAllBytes(newPath, pngByte); //Save the new png file(DrukaloScreenshot.png)
            File.Delete(path); //Delete old file (DrukaloScreenshot.t2D)
        }).Start();
    }
