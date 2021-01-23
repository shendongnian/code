    public static class StreamEx
    {
        public static void CopyTo(this Stream Input, Stream Output)
        {
            var buffer = new Byte[32768];
            Int32 bytesRead;
            while ((bytesRead = Input.Read(buffer, 0, buffer.Length)) > 0)
                Output.Write(buffer, 0, bytesRead);
        }
    }
