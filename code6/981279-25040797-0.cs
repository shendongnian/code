        [TestMethod]
        public void BarTest()
        {
            example.Expect(e => e.PreMethod());
            example.Expect(e => e.Stuff).Return(new[] { "One", "Two" });
            example.Expect(e => e.SomeThing)
                .SetPropertyWithArgument("One")
                .WhenCalled(obj => example.Expect(e => e.Foo()).Return("one"));
            example.Expect(e => e.SomeThing)
                .SetPropertyWithArgument("Two")
                .WhenCalled(obj => example.Expect(e => e.Foo()).Return("two"));
            example.Expect(e => e.PostMethod());
            
            var actual = example.Bar();
            
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("two", actual[0]);
            Assert.AreEqual("one", actual[1]);
            example.VerifyAllExpectations();
        }
