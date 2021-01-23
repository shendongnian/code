    var hostname = new HostName("www.w3.org");
    var socket = new StreamSocket();
    await socket.ConnectAsync(hostname, "80");
    var request = "GET /Protocols/rfc2616/rfc2616-sec4.html HTTP/1.1\r\n" +
              "Host: www.w3.org\r\n" +
              "\r\n";
    var writer = new DataWriter(socket.OutputStream);
    writer.WriteString(request);
    await writer.StoreAsync();
    var reader = new DataReader(socket.InputStream);
    reader.InputStreamOptions = InputStreamOptions.Partial;
    string data = string.Empty;    
    var cts = new CancellationTokenSource();
    bool doneReading = false;
    uint bytesToRead = 10240;
    while (!doneReading)
    {
      try
      {
        cts.CancelAfter(10 * 1000);
        await reader.LoadAsync(bytesToRead).AsTask(cts.Token);
        data += reader.ReadString(reader.UnconsumedBufferLength);
        totalBytesRead += bytesRead;
      }
      catch (TaskCanceledException)
      {
        doneReading = true;
      }
    }
    socket.Dispose();
