    [TestClass]
    public class ReturnServiceTest {
        [ClassInitialize()]
        public static void ClassInit(TestContext context) {
            //INIT TEST DATA FOR THE CLASS
        }
                
        [TestCleanup]
        public void TestCleanup() {
            //CLEANUP DATA AFTER EACH TEST
        }
        [TestMethod]
        public void IntegrationTestExample() {
            // Arrange without mocking
            var objec1 = new objec1();
            var objec2 = new objec2();
            var startTestClass = new startTestClass(objec1, objec2);
            var saveData = "test data";
            //Act
            startTestClass.SaveToDB(saveData);
            // Assert
            var valueFromDB = SelectSavedData();
            Assert.AreEqual(saveData, valueFromDB);
        }
        //Get data from DB for assert
        private string SelectSavedData() {
            var sqlQuery = "Select TOP 1 data from table1";
            var data = RepositoryForTest.selectSavedData(sqlQuery);
            return data;
        }
    }
