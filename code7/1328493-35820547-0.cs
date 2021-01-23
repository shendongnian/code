    public static class FormatRecognizer
    {
        public static Boolean IsZipFile(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(paramName: nameof(stream));
            var zipHeader = new Byte[]
            {
                0x50, 0x4B, 0x03, 0x04
            };
            var streamBytes = GetBytesAndRestore(stream, zipHeader.Length);
            return streamBytes.SequenceEqual(zipHeader);
        }
        public static Boolean IsOffice2003File(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(paramName: nameof(stream));
            var officeHeader = new Byte[]
            {
                0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1,
            };
            var streamBytes = GetBytesAndRestore(stream, officeHeader.Length);
            return streamBytes.SequenceEqual(officeHeader);
        }
        private static IEnumerable<Byte> GetBytesAndRestore(Stream stream, Int32 bytesCount)
        {
            if (stream == null)
                throw new ArgumentNullException(paramName: nameof(stream));
            var position = stream.Position;
            try
            {
                using (var reader = new BinaryReader(stream, Encoding.Default, leaveOpen: true))
                {
                    return reader.ReadBytes(bytesCount);
                }
            }
            finally
            {
                stream.Position = position;
            }
        }
    }
...
	private static void PrintFormatInfo(String path)
	{
		Console.WriteLine("File at '{0}'", path);
		using (var stream = File.Open(path, FileMode.Open))
		{
			PrintFormatInfo(stream);
		}
	}
	private static void PrintFormatInfo(Stream stream)
	{
		Console.WriteLine("Is office 2003 = {0}", FormatRecognizer.IsOffice2003File(stream));
		Console.WriteLine("Is zip file (possibly xlsx) = {0}", FormatRecognizer.IsZipFile(stream));
	}
