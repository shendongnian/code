    using System;
    using System.IO;
    public static class StreamExtensions
    {
        public static bool TryCopyToExact(this Stream inputStream, Stream outputStream, byte[] buffer, int bytesToCopy)
        {
            if (inputStream == null)
            {
                throw new ArgumentNullException("inputStream");
            }
            if (outputStream == null)
            {
                throw new ArgumentNullException("outputStream");
            }
            if (buffer.Length <= 0)
            {
                throw new ArgumentException("Invalid buffer specified", "buffer");
            }
            if (bytesToCopy <= 0)
            {
                throw new ArgumentException("Bytes to copy must be positive", "bytesToCopy");
            }
            int bytesRead;
            while (bytesToCopy > 0 && (bytesRead = inputStream.Read(buffer, 0, Math.Min(buffer.Length, bytesToCopy))) > 0)
            {
                outputStream.Write(buffer, 0, bytesRead);
                bytesToCopy -= bytesRead;
            }
            return bytesToCopy == 0;
        }
        public static void CopyToExact(this Stream inputStream, Stream outputStream, byte[] buffer, int bytesToCopy)
        {
            if (!TryCopyToExact(inputStream, outputStream, buffer, bytesToCopy))
            {
                throw new IOException("Failed to copy the specified number of bytes");
            }
        }
    }
