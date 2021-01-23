    [Test, AutoMoqData]
        public void Hash_Algorithm_Correct (
            [NoAutoProperties] HashMacService sut,
            string message)
        {
            string expected;
            var key = Encoding.UTF8.GetBytes(Constants.API_KEY);
            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                expected = Convert.ToBase64String(hash);
            }
            var result = sut.ComputeHMAC(message);
            Assert.That(result, Is.EqualTo(expected));
        }
