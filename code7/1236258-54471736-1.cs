public static string RandomString(int length)
{
    const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    var res = new StringBuilder(length);
    using (var rng = new RNGCryptoServiceProvider())
    {
        int count = (int)Math.Ceiling(Math.Log(alphabet.Length, 2) / 8.0);
        Debug.Assert(count <= sizeof(uint));
        int offset = BitConverter.IsLittleEndian ? 0 : sizeof(uint) - count;
        int max = (int)(Math.Pow(2, count*8) / alphabet.Length) * alphabet.Length;
        byte[] uintBuffer = new byte[sizeof(uint)];
        while (res.Length < length)
        {
            rng.GetBytes(uintBuffer, offset, count);
            uint num = BitConverter.ToUInt32(uintBuffer, 0);
            if (num < max)
            {
                res.Append(alphabet[(int) (num % alphabet.Length)]);
            }
        }
    }
    return res.ToString();
}
