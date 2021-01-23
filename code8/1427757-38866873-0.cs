    private BlockingCollection<Tuple<double?, double?>> _queue = new BlockingCollection<Tuple<double?,double?>>();
    private string _filePath;
    private Thread _workerThread;
    private bool _isDisposed;
    private void DoWork()
    {
        if(_queue == null)
            return;
        
        if(!File.Exists(_filePath))
            return;
        var file = File.Open(_filePath);
        foreach(var values in _queue)
        {
           try
           {
               file.WriteLine($"{values.Item1},{values.Item2}");
           }
           catch (Exception ex) { ex.ToString(); }
           }
        }
        file.Close();
    }
    public void Dispose()
    {
        if (!_isDisposed)
        {
            _queue.CompleteAdding();
            _isDisposed = true;
            _workerThread.Join();
        }
    }
    public FFTWriter(string filePath)
    {
        _filePath = filePath;
        _workerThread = new Thread(DoWork);
        _workerThread.Start();
    }
    public void WriteValues(double? v1, double? v2)
    {
        if (v1.HasValue == true && v2.HasValue == true)
        _queue.Add(new Tuple<double?,double?>(v1.Value, v2.Value));
    }
