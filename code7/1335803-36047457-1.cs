    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PoliciesAreSortedByCAfirst()
        {
            var unsorted = new Policy[]
            {
                new Policy{Number = new PolicyNumber("AB10001")},
                new Policy{Number = new PolicyNumber("CA20003")},
                new Policy{Number = new PolicyNumber("CA20001")}
            };
            var sorted = unsorted.OrderBy(policy => policy.Number);
            var expectedOrder = new Policy[]
            {
                unsorted[2], unsorted[1], unsorted[0]
            };
            Assert.IsTrue(expectedOrder.SequenceEqual(sorted));
        }
    }
