    bool keepIncrementing = false;
    public static int pscore = 0;
    void Start()
    {
        StartCoroutine(IncementEachSecond());
    }
    
    IEnumerator IncementEachSecond()
    {
        keepIncrementing = true;
        while (keepIncrementing)
        {
            pscore++;
            yield return new WaitForSeconds(1);
        }
    }
    
    void stopIncrementing()
    {
        keepIncrementing = false;
    }
