    public class Primitive
    {
        public string type;
        public float[] vertices;
        [JsonFx.Json.JsonIgnore]
        public int[] indices;
        [JsonFx.Json.JsonName("indices")]
        public string compressedIndices
        {
            get
            {
                return indices.Base64Compress();
            }
            set
            {
                indices = CompressionExtensions.Base64DecompressIntArray(value);
            }
        }
        public int[] edgeIndices;
        [JsonFx.Json.JsonIgnore]
        public Scene scene;
    }
    public static class CompressionExtensions
    {
        public static string Base64Compress(this IEnumerable<int> values)
        {
            if (values == null)
                return null;
            using (var stream = new MemoryStream())
            {
                using (var compressor = new DeflateStream(stream, CompressionMode.Compress, true))
                {
                    var _buffer = new byte[4];
                    foreach (var value in values)
                    {
                        _buffer[0] = (byte)value;
                        _buffer[1] = (byte)(value >> 8);
                        _buffer[2] = (byte)(value >> 16);
                        _buffer[3] = (byte)(value >> 24);
                        compressor.Write(_buffer, 0, 4);
                    }
                }
                return Convert.ToBase64String(stream.GetBuffer(), 0, checked((int)stream.Length)); // Throw an exception on overflow.
            }
        }
        public static int[] Base64DecompressIntArray(string base64)
        {
            if (base64 == null)
                return null;
            var list = new List<int>();
            var m_buffer = new byte[4];
            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
            {
                using (var compressor = new DeflateStream(stream, CompressionMode.Decompress))
                {
                    while (compressor.Read(m_buffer, 0, 4) == 4)
                    {
                        list.Add((int)(m_buffer[0] | m_buffer[1] << 8 | m_buffer[2] << 16 | m_buffer[3] << 24));
                    }
                }
            }
            return list.ToArray();
        }
    }
