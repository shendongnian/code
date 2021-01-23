    private class StartEndLoopReader:IWaveProvider
    {
        private TimeSpan _start;
        private TimeSpan _end;
        private WaveStream _stream;
    
        public StartEndLoopReader(WaveStream stream, TimeSpan start, TimeSpan end)
        {
            _stream = stream;
            _stream.CurrentTime = start;
            _start = start;
            _end = end;
        }
    
        public int Read(byte[] array, int offset, int count)
        {
            Debug.WriteLine(_stream.CurrentTime);
            if (_stream.CurrentTime>_end)
            {
                // back to start to loop 
                // if you want to stop here, return 0 instead.
                _stream.CurrentTime = _start;
            }
                    
            return _stream.Read(array, offset, count);    
        }
    
        #region IWaveProvider Members
        public WaveFormat WaveFormat
        {
            get { return _stream.WaveFormat; }
        }
        #endregion
    }
