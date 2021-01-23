    void Start()
    {
        StartCoroutine(readKey());
    }
    
    bool keepReading = false;
    IEnumerator readKey()
    {
        if (keepReading)
        {
            yield break;
        }
        keepReading = true;
    
        yield return null;
    
        while (keepReading)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Hello!");
            }
            else
            {
                Debug.Log("Not down!");
            }
            yield return null;
        }
    }
    
    void stopReading()
    {
        keepReading = false;
    }
