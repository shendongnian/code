    void Retry(Action action)
    {
        for (int retry = 0; retry < retrycount; retry++)
        {
            try
            {
                action();
                break;
            }
            catch (Exception ex)
            {
                Thread.sleep (5000);
            }
        }
    }
    …
    Retry(() => methodA(p1, p2));
