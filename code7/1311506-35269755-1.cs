    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMongoInsertionAsync()
        {
            Mongoclass mc = new Mongoclass();
            await mc.SaveToMongoAsync();
        }
    }
