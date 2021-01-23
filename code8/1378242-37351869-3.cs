    [TestClass]
    public class CalendarTests {
    
        private class FakeServerVariable : IServerVariable {
            public string Name { get { return "test.org"; }
        }
    
        public CalendarRepository _repo { get; set; }
    
        [TestInitialize]
        public void Setup() {
            _repo = new CalendarRepository();
    
            Helpers.ServerVariable = new FakeServerVariable();
        }
    
        [TestMethod]
        public void CreateEventTest() {
    
            int val = _repo.CreateEvent(1,
                                        "test title",
                                        "demo-description",
                                        DateTime.Now,
                                        DateTime.Now.AddDays(1),
                                        true,
                                        1,
                                        1);
    
            Assert.IsTrue(val > 0);
        }
    }
