        private static void StartListening()
        {
            _dataLength = (_dataLength < (32 * 1024)) ? 32 * 1024 : _dataLength;
            while (!_shouldStop) // _shouldStop is a boolean private field
            {
                try
                {
                    if (_stream.DataAvailable) // _stream is a NetworkStream
                    {
                        Byte[] buffer = new Byte[_dataLength];
                        Int32 readBytes = _stream.Read(buffer, 0, buffer.Length);
                        // ResponseData is a property of type String
                        ResponseData = UTF8Encoding.UTF8.GetString(buffer, 0, readBytes);
                    }
                }
                catch (IOException ioex)
                {
                    // Do nothing since the client and socket are already closed.
                }
            }
        }
