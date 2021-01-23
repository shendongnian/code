    public async void Start()
    {
        int x = 100/Timer; // percent per second
        for (i = Value; i > 0; i--) {
           Value -= x;
           await Task.Delay(1000);
        }
    }
