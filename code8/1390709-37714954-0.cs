    public long DownloadPeriod
    {
        get { return _DownloadPeriod; }
        set
        {
            if (value > 0) _DownloadPeriod = value;
            else throw new Exception("invalid value");
        }
    }
    private long _DownloadPeriod;
