    public static async Task<byte[]> ReadFromSocket(StreamSocket socket)
    {
        using (var output = new MemoryStream())
        {
            var bytesCopied = await RandomAccessStream.CopyAsync(socket.InputStream, output.AsOutputStream());
            if (bytesCopied > 0)
                return output.ToArray();
        }
        return new byte[0];
    }
    
    public static IAsyncOperationWithProgress<uint,uint> WriteToSocket(StreamSocket socket, byte[] bytes)
    {
        return socket.OutputStream.WriteAsync(bytes.AsBuffer());
    }
