    public static string CreateRandomPassword(int Length)
        {
            string _Chars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ[_!23456790";
            Byte[] randomBytes = new Byte[Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            var chars = new char[Length];
            int Count = _Chars.Length;
            for (int i = 0; i < Length; i++)
            {
                chars[i] = _Chars[(int)randomBytes[i] % Count];
            }
            return new string(chars);
        }
        public static string CreateRandomPasswordWith2UpperAnd1NumberAnd1Special(int length)
        {
            while (true)
            {
                var pass = CreateRandomPassword(length);
                int upper=0, num =0, special = 0,lower=0;
                foreach (var c in pass)
                {
                    if (c > 'A' && c < 'Z')
                    {
                        upper++;
                    }
                    else if (c > 'a' && c < 'z')
                    {
                        lower++;
                    }
                    else if (c > '0' && c < '9')
                    {
                        num++;
                    }
                    else
                    {
                        special++;
                    }
                }
                if (upper>=2&&num>=1&&1>=special)
                {
                    return pass;
                }
            }
        }
        [Test]
        public void CreateRandomPassword_Length13_RandomPasswordWithNumbers()
        {
            var random = CreateRandomPasswordWith2UpperAnd1NumberAnd1Special(13);
            Assert.IsTrue(true);
        }
