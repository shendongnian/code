        [TestMethod]
        public void EnsureDerivedClassCallsBaseClass()
        {
            var testSubject = new TheDerivedClass();
            testSubject.WriteToOutput();
            Assert.IsTrue(testSubject.Output.Contains("TheBaseClass"));
        }
