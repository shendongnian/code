    [Theory]
        [MemberData("RequestFakeData")]
        public void Should_Throw_Exception_RequestDate(int amount, string description, DateTime requestDate)
        {
            Exception ex = Assert.Throws<Exception>(() => new AssistanceRequest(amount,description,requestDate));
            Assert.Equal("Request Time is not Allowed",ex.Message);
        }
        public static IEnumerable<object[]> RequestFakeData
        {
            get
            {
                return new[]
                {
                new object[] { 1,string.Empty,DateTime.Now },
                new object[] { 2,"",DateTime.Now.AddDays(-2) },
                new object[] { 1,string.Empty,DateTime.Now.AddDays(-3) },
                };
            }
        }
