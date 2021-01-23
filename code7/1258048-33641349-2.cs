        [TestMethod]
        public void TestMethod1()
        {
            var sales = new List<Sale>
            {
                new Sale() {id = 1},
                new Sale() {id = 6},
                new Sale() {id = 5},
                new Sale() {id = 4},
                new Sale() {id = 3},
                new Sale() {id = 2}
            };
            var fakeContest = new Mock<SalesContext>();
            Mock<DbSet<Sale>> fakeSet;
            fakeContest.Setup(context => context.Sales).ReturnsDbSet(sales, out fakeSet);
            var itemsToRemove = sales.Where(sale => sale.id%2 == 0);
            fakeContest.Object.Sales.RemoveRange(itemsToRemove);
            
            fakeSet.Verify(set => set.RemoveRange(itemsToRemove));
        }
