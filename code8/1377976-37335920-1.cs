        [Test]
        public void TestLookup2()
        {
            var repo = Substitute.For<IRepo> ();
            var sut = new Sut (repo);
            Func<Merchant, bool> query = x => false;
            repo.GetBy (Arg.Do<Expression<Func<Merchant, bool>>> (x => query = x.Compile()));
            sut.GetByExtId ("123");
            Assert.IsTrue(query (new Merchant { ExternalId = "123" }));
            Assert.IsFalse(query (new Merchant { ExternalId = "123zxcv" }));
        }
