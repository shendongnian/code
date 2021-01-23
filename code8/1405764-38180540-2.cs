    public string InputRead => plc.InputImage[1].ToString();
    void ThreadFunc()
    {
        while (threadRunning)
        {
            plc.Read();
            Dispatcher.Invoke(() => OnPropertyChanged(nameof(InputRead)));
        }
    }
