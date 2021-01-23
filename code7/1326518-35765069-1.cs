    private void Read()
    {
        while (!cancelToken.IsCancellationRequested)
        {
            if(deviceStream.CanRead && deviceStream.Length > 0)
                int bytesReaded = deviceStream.Read(buffer, 0, bufferSize);
        }
    }
