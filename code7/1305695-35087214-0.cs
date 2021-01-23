    class MyWriter : IDisposable
    {
        BinaryWriter _writer;
        readonly int _maxLineLength, _maxLines, _size;
    
        public MyWriter(string path, int maxLineLength, int maxLines)
        {
            _maxLineLength = maxLineLength;
            _maxLines = maxLines;
            _size = _maxLineLength * _maxLines;
    
            _writer = new BinaryWriter(File.Create(path));
            _writer.BaseStream.SetLength(_size);
        }
    
        public void Write(string str)
        {
            if (str.Length > _maxLineLength) throw new ArgumentOutOfRangeException();
            // Write the string to the current poisition in the stream.
            // Pad the rest of the line with null.
            _writer.Write(str.PadRight(_maxLineLength, '\0').ToCharArray());
            // If the end of the stream is reached, simply loop back to the start.
            // The oldest entry will then be overwritten next.
            if (_writer.BaseStream.Position == _size)
                _writer.Seek(0, SeekOrigin.Begin);
        }
    
        public void Dispose()
        {
            if(_writer != null)
                _writer.Dispose();
        }
    }
