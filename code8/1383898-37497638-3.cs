    public RawImage defaultRawImage;
    RawImage[] rawImages;
    Texture2D texture = null;
    int currentPreviewNumber = 0;
    string appPath;
    System.Text.StringBuilder imagePath;
    byte[] tBytes;
    
    void Start()
    {
        appPath = Application.persistentDataPath;
    
        //Init Texture 2D
        texture = new Texture2D(100, 100, TextureFormat.RGB24, false);
    
        //Init All 12 Raw Images
        rawImages = new RawImage[12];
        for (int i = 0; i < rawImages.Length; i++)
        {
            rawImages[i] = Instantiate(defaultRawImage) as RawImage;
        }
    
        //Init String Builder
        imagePath = new System.Text.StringBuilder(300);
        tBytes = new byte[90000];
    }
    
    
    void loadPreviewOptimized()
    {
        while (currentPreviewNumber < 12)
        {
            //Debug.Log(currentPreviewNumber);
    
            //Reset Capacity before Reading
            imagePath.Capacity = 0;
            imagePath.Append(appPath).Append("/").Append(currentPreviewNumber).Append(".jpg");
    
            //Read File
            using (System.IO.FileStream myfile = System.IO.File.Open(imagePath.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
            {
                //Check if array size is enough before writing
                if (tBytes.Length >= myfile.Length)
                {
                    //OK (Write file to tBytes array)
                    myfile.Read(tBytes, 0, (int)myfile.Length);
                    texture.LoadImage(tBytes);
                }
                else
                {
                    //NOT OK (Resize array size)
                    tBytes = new byte[myfile.Length];
    
                    //Write file to tBytes array
                    myfile.Read(tBytes, 0, (int)myfile.Length);
                    texture.LoadImage(tBytes);
                }
    
                rawImages[currentPreviewNumber].texture = texture;
                currentPreviewNumber++;
            }
        }
    }
