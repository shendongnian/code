        [TestMethod]
        public void StubRegFuncTest()
        {
            StubITestReader stubClass = new StubITestReader();
            stubClass.ExecuteNonQueryStringInt32 = (str, timeout) => timeout * 2;
            ITestReader reader = stubClass;
            int curInt = reader.ExecuteNonQuery("testText");
            Console.WriteLine(curInt);
            curInt = reader.ExecuteNonQuery("testText", 10);
            Console.WriteLine(curInt);
        }
