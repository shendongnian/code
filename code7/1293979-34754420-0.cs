        [Test]
        public void StubMultipleCalls() {
            Func<string> throwEx = () => { throw new Exception(); };
            var sub = Substitute.For<IThingoe>();
            // Stub method to fail twice, then return valid data
            sub.MethodToRetry(Arg.Any<string>())
               .Returns(x => throwEx(), x => throwEx(), x => "works now");
            // The substitute will then act like this:
            Assert.Throws<Exception>(() => sub.MethodToRetry("")); 
            Assert.Throws<Exception>(() => sub.MethodToRetry("")); 
            Assert.AreEqual("works now", sub.MethodToRetry(""));
            // Will continue returning last stubbed value...
            Assert.AreEqual("works now", sub.MethodToRetry(""));
            Assert.AreEqual("works now", sub.MethodToRetry(""));
        }
