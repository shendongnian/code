    private AutoResetEvent _outputResetEvent;
    private bool _hasError;
    private StringBuilder _outputMessage;
    private void EvaluateWithPython(string expression)
    {
        // Set _outputResetEvent to unsignalled state
        _outputResetEvent.Reset();
        // Reset _hasError, 
        _hasError = true;
        // Write command to python, using its dedicated method
        childInput.WriteLine("PythonEval('" + expression + "')"); // The ' chars again are important, as the eval method in python takes a string, which is indicated by 's in python
        // wait for python to write into stdOut, which is captured by OnOutputDataReceived (below) and sets _outputResetEvent to signalled stat
        bool _timeoutOccured = _outputResetEvent.WaitOne(5000);
        
        // Give OnOutputDataReceived time to finish
        Task.Delay(200).Wait();        
    }
    private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (e == null)
        {
            throw new ArgumentNullException();
        }
        if (e.Data != null)
        {
            // Pass message into StringBuilder line by line, as OnOutputDataReceived is called line by line
            _outputMessage.AppendLine(e.Data);
            // Check for end of message, this is in all cases of the form "CHILD: DONE|ERROR"
            // In this case, set errorFlag if needed and signal the AutoResetEvent
            if (e.Data.Equals("CHILD: ERROR"))
            {
                _hasError = true;
                _outputResetEvent.Set();
            }
            else if (e.Data.Equals("CHILD: DONE"))
            {
                _hasError = false;
                _outputResetEvent.Set();
            }
        }
        else
        {
            // TODO: We only reach this point if child python process ends and stdout is closed (?)
            _outputResetEvent.Set();
        }
        
    }
