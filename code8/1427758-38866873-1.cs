    private FFTWriter _writer;
    private void StartNewFFT()
    {
        _writer = new FFTWriter(path);
    } 
    private void FftCalculated(object sender, FftEventArgs e)
    {
        _writer.WriteValues(e.Result);  
    }
