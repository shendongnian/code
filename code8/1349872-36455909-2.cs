    static byte[] GetTestingBytes()
    {
            var str = String.Join(",", Enumerable.Range(0, 1000).Select(x => Guid.NewGuid()).ToArray());
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
    }
