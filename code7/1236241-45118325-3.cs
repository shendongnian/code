        const string lookupCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        static void TestRandomString()
        {
            Console.WriteLine("A random string of 100 characters:");
            int[] randomCharacterIndexes = new int[100];
            SecureRangeOriginal(randomCharacterIndexes, lookupCharacters.Length);
            var sb = new StringBuilder();
            for (int i = 0; i < randomCharacterIndexes.Length; i++)
            {
                sb.Append(lookupCharacters[randomCharacterIndexes[i]]);
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine();
        }
        static void SecureRangeOriginal(int[] result, int maxInt)
        {
            if (maxInt > 256)
            {
                //If you copy this code, you can remove this line and replace it with `throw new Exception("outside supported range");`
                SecureRandomIntegerRange(result, 0, result.Length, 0, maxInt);  //See git repo for implementation.
                return;
            }
            var maxMultiples = 256 / maxInt; //Finding the byte number boundary above the provided lookup length - the number of bytes
            var exclusiveLimit = (maxInt * maxMultiples); //Expressing that boundary (number of bytes) as an integer
            var length = result.Length;
            var resultIndex = 0;
            using (var provider = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[length];
                while (true)
                {
                    var remaining = length - resultIndex;
                    if (remaining == 0)
                        break;
                    provider.GetBytes(buffer, 0, remaining);
                    for (int i = 0; i < remaining; i++)
                    {
                        if (buffer[i] >= exclusiveLimit)
                            continue;
                        var index = buffer[i] % maxInt;
                        result[resultIndex++] = index;
                    }
                }
            }
        }
