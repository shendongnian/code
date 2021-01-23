    public event Action<string> DataReady;
    DataReady?.Invoke("data");
    dll.DataReady += OnDataReady;
    public void OnDataReady(string arg1)
    {
       label.Text = arg1;
    }
