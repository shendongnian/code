        [Test]
        public void TestContains()
        {
            var instance = new SomeClass();
            const string key = "someKey";
            Assert.IsFalse(instance.Contains(key));
            // A purest will say that you don't need the following Assert
            // for the Add as it is not what you are testing. 
            // But I don't see any harm
            Assert.IsTrue(instance.Add(key, new object()));
            Assert.IsTrue(instance.Contains(key));
            instance.Remove(key);
            Assert.IsFalse(instance.Contains(key));
        }
