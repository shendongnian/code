        [TestMethod]
        public void SimpleTest()
        {
            TestUnitTestClass tutClass = new TestUnitTestClass();
            using (ShimsContext.Create())
            {
                ShimTestUnitTestClass shimClass = new ShimTestUnitTestClass(tutClass);
                shimClass.AnotherFunctionInt32 = (val) =>
                {
                    if (val == 3)
                        return 34;
                    if (val == 4)
                        return 44;
                    return 22;
                };
                int curInt = tutClass.AnotherFunction(3);
                Console.WriteLine(curInt);
            }
        }
