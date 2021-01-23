        class Test<X>
        {
            private readonly Func<string, X> ParseMethod;
            public Test(Func<string, X> parseMethod)
            {
                this.ParseMethod = parseMethod;
            }
            public X GetDataValue(int id)
            {
                string idstring = "3-mar-2010";
                return this.ParseMethod(idstring);
            }
        }
        [TestMethod]
        public void TestParse()
        {
            var parser = new Test<DateTime>(DateTime.Parse);
            DateTime dt = parser.GetDataValue(1);
            Assert.AreEqual(new DateTime(day: 3, month: 3, year: 2010), dt);
        }
