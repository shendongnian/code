        [TestMethod]
        public void PoliciesAreSortedByCAfirst()
        {
            var unsorted = new Policy[]
            {
                new Policy {PolicyNumber = "AB10001"},
                new Policy {PolicyNumber = "CA20003"},
                new Policy {PolicyNumber = "CA20001"}
            };
            var sorted = unsorted.Sort();
            var expectedOrder = new string[] {"CA20001", "CA20003", "AB10001"};
            Assert.IsTrue(expectedOrder.SequenceEqual(sorted.Select(policy=>policy.PolicyNumber)));
        }
