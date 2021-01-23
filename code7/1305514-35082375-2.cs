    [TestFixture]
    public class DatabaseUnitTest
    {
        [Test]
        public void Test()
        {
            var logger = new Mock<IBLLogger>(MockBehavior.Strict);
            var blDataPopulation = new Mock<IBLDataPopulation>(MockBehavior.Strict);
            var database = new Mock<IDatabase>(MockBehavior.Strict);
            var toTest = new ClassToTest(logger.Object, blDataPopulation.Object, database.Object);
            var userId = Guid.NewGuid();
            var culture = new Culture{Id = "MyId"};
            var dataSet = new DataSet();
            var table = new DataTable();
            dataSet.Tables.Add(table);
            database.Setup(x => x.ProvideCultureMappings(userId, culture)).Returns(dataSet);
            var cultureList = new List<Culture> {culture, new Culture {Id = "AnotherCulture"}};
            blDataPopulation.Setup(x => x.PopulateCultures(table)).Returns(cultureList);
            var result = toTest.UpdatePersonCulture(userId, culture);
            Assert.AreEqual(result.Id, culture.Id);
        }
    }
