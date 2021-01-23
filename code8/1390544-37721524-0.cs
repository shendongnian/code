        [TestMethod]
        public void UnitTestExample()
        {
            var orgs = new Organisation
            {
                Ids = new List<int>{ 1,3 },
                DealerCodes = new List<string> { "foo","bar"}
            };
            var members = new Organisation
            {
                Ids = new List<int> { 1,2,3 },
                DealerCodes = new List<string> { "foo", "bar", "buzz" }
            };
            orgs.ShouldSatisfyAllConditions(
                () => orgs.Ids.ShouldBe(members.Ids, ignoreOrder: true),
                () => orgs.DealerCodes.ShouldBe(members.DealerCodes, ignoreOrder: true)
                );
        }
