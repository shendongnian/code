    int _worker_processes = 1;
    [Browsable(true),ReadOnly(true),Category("General"),Description("Defines the number of worker processes. Windows only supports one.")]
    public int worker_processes
    {
        get { return _worker_processes; }
        set { _worker_processes = value; }
    }
