    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = enable;
    }
    
    void EnableVR()
    {
        StartCoroutine(LoadDevice("daydream", true));
    }
    
    void DisableVR()
    {
        StartCoroutine(LoadDevice("", false));
    }
