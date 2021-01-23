        [TestMethod]
        public void StubFuncTest()
        {
            StubITestReader stubClass = new StubITestReader();
            stubClass.ExecuteReaderOf1StringFuncOfIDataRecordM0Int32<int>((str, func, timeout) =>
            {
                int[] retVal = {12, 25, 15};
                return retVal;
            });
            ITestReader reader = stubClass;
            IEnumerable<int> curInt = reader.ExecuteReader<int>("testText", TestFunc);
            foreach (var i in curInt)
            {
                Console.WriteLine(i);
            }
        }
