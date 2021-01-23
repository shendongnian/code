         [TestMethod]
        public void Test_Service_When_Passing_String_And_ActionDelegate()
        {
            var fakeReporter = new Mock<IRepeater>();
            fakeReporter.Setup(x => x.Each(It.IsAny<string>(), It.IsAny<Action<string>>()))
                .Callback<string, Action<string>>((s, action) =>
                {
                    Assert.AreEqual("asdfghj", s);
                    foreach (var w in "pass")
                    {
                        action(w.ToString());
                    }
                });
            var target = new Service(fakeReporter.Object);
            var result = target.Parse("asdfghj");
            Assert.AreEqual("pass", result);
        }
