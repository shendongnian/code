    private BlockingCollection<IEnumerable<FFTResult>> _queue = new BlockingCollection<IEnumerable<FFTResult>>();
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
        foreach(var results in _queue)
        {
           try
           {
               foreach(var values in results)
               {
                   if (values.X.HasValue == true && values.Y.HasValue == true)
                       file.WriteLine($"{values.X},{values.Y}");
               }
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
    public void WriteValues(IEnumerable<FFTResult> results)
    {
        _queue.Add(new Tuple<double?,double?>(v1.Value, v2.Value));
    }
