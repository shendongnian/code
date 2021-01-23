    [TestCase]
    public class GivenCustomerChanged_ThenMaximizePostCall
    {
        [Test]
        public void Test() 
        {
             var masterViewModel = new MasterViewModel();
             using (var childViewModel = new ChildViewModel(masterViewModel))
             {
                  masterViewModel.Customer = new Customer();
             }
             // assert that MaximizePostCall was called
        }
    }
