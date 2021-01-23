    private void OnStreamAvailable(Stream stream, HttpContent content,TransportContext context)
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
               byte[] buffer = _symboleService.GetAll();
               await writer.WriteAsync(buffer, 0, buffer.Length);
            }
        }
