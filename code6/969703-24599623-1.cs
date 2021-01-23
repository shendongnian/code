    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void MyPropertyTest()
        {
            string expected = "expected";
            var vm = new MainViewModel();
            
            vm.MyProperty = expected;
            Assert.AreEqual(expected, vm.MyProperty);    
        }
    }
