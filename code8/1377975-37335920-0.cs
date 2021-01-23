        [Test]
        public void TestLookup ()
        {
            var repo = Substitute.For<IRepo> ();
            var sut = new Sut (repo);
            sut.GetByExtId ("123");
            repo.Received (1).GetBy (Arg.Is<Expression<Func<Merchant, bool>>> (x => ComparesMerchantId (x)));
        }
        bool ComparesMerchantId (Expression<Func<Merchant, bool>> x)
        {
            // Option 1: inspect expression tree and make sure it matches what you want.
            // Option 2: run the expression and check it behaves as you expect.
            var f = x.Compile ();
            return f (new Merchant { ExternalId = "123" }) && !f (new Merchant { ExternalId = "999" });
        }
