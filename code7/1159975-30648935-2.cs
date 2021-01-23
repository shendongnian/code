       [Test]        
        public void TestAdd()
        {
            var instance = new SomeClass();
            const string key = "someKey";
            Assert.IsTrue(instance.Add(key, new object()));
        }
