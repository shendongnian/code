    internal void Start()
    {
        _nodeProcess.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
        _nodeProcess.BeginOutputReadLine();
        _nodeProcess.Start();
    }
