    void Start()
    {
    
        IWaveSource audio = CodecFactory.Instance.GetCodec(pathToMP3File);
        ISoundOut device = new WasapiOut();
        device.Initialize(audio);
    
        try
        {
            device.Play(); // the call causing the crash
            Debug.Log("Sound Played!");
        }
        catch (System.Exception e)
        {
            Debug.Log("Error playing sound: " + e.Message);
        }
    }
