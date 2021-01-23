    public class RollingFileWriter : TextWriter
    {
        private readonly string _filenamePrefix;
        private readonly string _fileNameSuffix;
        private readonly int _maxRecordCount;
        private Stream _innerStream;
        private int _recordCount = 0;
        private int _fileCounter = 0;
        public RollingFileWriter( string filenamePrefix, string fileNameSuffix = ".txt", int maxRecordCount = 500000 )
        {
            _filenamePrefix = filenamePrefix;
            _fileNameSuffix = fileNameSuffix;
            _maxRecordCount = maxRecordCount;
            _innerStream = new FileStream(
                _filenamePrefix + "_" + _fileCounter.ToString() + _fileNameSuffix,
                FileMode.Create );
        }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
        public override void Write( char value )
        {
            _innerStream.Write( Encoding.GetBytes( new[] { value } ), 0, 1 );
        }
        public override void WriteLine( string value )
        {
            if ( ++_recordCount == _maxRecordCount )
            {
                SwitchStreams();
            }
            base.WriteLine( value );
        }
        private void SwitchStreams()
        {
            _innerStream.Close();
            _innerStream.Dispose();
            _innerStream = new FileStream(
                _filenamePrefix + "_" + ( ++_fileCounter ).ToString() + _fileNameSuffix,
                FileMode.Create );
            _recordCount = 0;
        }
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                _innerStream.Dispose();
            }
        }
    }
