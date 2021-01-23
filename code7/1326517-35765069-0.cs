    private void Read()
    {
        while (!cancelToken.IsCancellationRequested)
        {
            if(deviceStream.CanRead)
                int bytesReaded = deviceStream.Read(buffer, 0, bufferSize);
        }
    }
