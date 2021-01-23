        [Test]
        public void ReplaceLambda() {
            Func<string> methodToRetry = () => { throw new Exception(); };
            var sub = Substitute.For<IThingoe>();
            sub.MethodToRetry(Arg.Any<string>()).Returns(x => methodToRetry());
            Assert.Throws<Exception>(() => sub.MethodToRetry(""));
            methodToRetry = () => "works now";
            Assert.AreEqual("works now", sub.MethodToRetry(""));
        }
