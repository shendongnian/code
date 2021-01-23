    System.Threading.ThreadStart th_start = () =>
    {
        slowFunction(arg);
              
    };
    System.Threading.Thread th = new System.Threading.Thread(th_start)
    {
        IsBackground = true
    };
    th.Start();
