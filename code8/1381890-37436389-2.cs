    public static DateTime TimeLeft { get; set; }
    void OnMouseOver()
    {
        TimeSpan span = DateTime.Now - TimeLeft;
        int ms = (int)span.TotalMilliseconds;
        if (ms > 2000)
        {
            ClearLabel();
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            HitCounter++;
            StartCoroutine(ShowHitCounter(HitCounter.ToString(), 2)); 
        }
    }
