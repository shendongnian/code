        [Test]
        public void StubWithCondition() {
            var shouldThrow = true;
            var sub = Substitute.For<IThingoe>();
            sub.MethodToRetry(Arg.Any<string>()).Returns(x => {
                if (shouldThrow) {
                    throw new Exception();
                }
                return "works now";
            });
            Assert.Throws<Exception>(() => sub.MethodToRetry(""));
            shouldThrow = false; // <-- can alter behaviour by modifying this variable
            Assert.AreEqual("works now", sub.MethodToRetry(""));
        }
