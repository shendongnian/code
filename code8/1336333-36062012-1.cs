    public class SomeClass
    {
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public byte[] SHA256()
        {
            using (var sha256 = new SHA256Managed())
            {
                var strings = new[] { Str1, Str2, Str3, Str4 };
                for (int i = 0; i < strings.Length; i++)
                {
                    string str = strings[i];
                    int length = str != null ? str.Length : -1;
                    byte[] length2 = BitConverter.GetBytes(length);
                    sha256.TransformBlock(length2, 0, length2.Length, length2, 0);
                    if (str != null)
                    {
                        byte[] sortKeyBytes = CultureInfo.InvariantCulture.CompareInfo.GetSortKey(str, CompareOptions.IgnoreCase).KeyData;
                        sha256.TransformBlock(sortKeyBytes, 0, sortKeyBytes.Length, sortKeyBytes, 0);
                    }
                }
                sha256.TransformFinalBlock(new byte[0], 0, 0);
                byte[] hash = sha256.Hash;
                return hash;
            }
        }
    }
