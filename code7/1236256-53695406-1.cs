    private static string GenerateRandomSecret()
    {
        var validChars = Enumerable.Range('A', 26)
            .Concat(Enumerable.Range('a', 26))
            .Concat(Enumerable.Range('0', 10))
            .Select(i => (char)i)
            .ToArray();
        var randomByte = new byte[64 + 1]; // Max Length + Length
        using (var rnd = new RNGCryptoServiceProvider())
        {
            rnd.GetBytes(randomByte);
            var secretLength = 32 + (int)(32 * (randomByte[0] / (double)byte.MaxValue));
            return new string(
                randomByte
                    .Skip(1)
                    .Take(secretLength)
                    .Select(b => (int) ((validChars.Length - 1) * (b / (double) byte.MaxValue)))
                    .Select(i => validChars[i])
                    .ToArray()
            );
        }
    }
