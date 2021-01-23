    [TestClass]
    public class CustomerTypeTests : DatabaseTest
    {
        private CustomerType customerType;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            customerType = new CustomerType
                           {
                               Name = "Customer Type"
                           };
        }
     
        [TestMethod]
        public void AddOrUpdateCustomerType_ThrowExceptionIfNameIsNull()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => DatabaseContext.AddOrUpdateCustomerType(customerType));
        }
    }
