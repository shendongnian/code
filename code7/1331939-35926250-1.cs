        [TestMethod]
        public void ShimFuncTest()
        {
            TestUnitTestClass tutClass = new TestUnitTestClass();
            using (ShimsContext.Create())
            {
                ShimTestUnitTestClass shimClass = new ShimTestUnitTestClass(tutClass);
                shimClass.ExecuteReaderOf1StringFuncOfIDataRecordM0Int32<int>((str, func, timeout) =>
                {
                    int[] retVal = {12, 25, 15};
                    return retVal;
                });
                IEnumerable<int> curInt = tutClass.ExecuteReader<int>("testText", TestFunc);
                foreach (var i in curInt)
                {
                    Console.WriteLine(i);                    
                }
            }
        }
