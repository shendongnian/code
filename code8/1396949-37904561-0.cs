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
        [Test]
        public void CreateRandomPassword_Length13_RandomPasswordWithNumbers()
        {
            var random = CreateRandomPassword(13);
            Assert.IsTrue(random.Any(c=>c >'0'&&c<'9'));
        }
