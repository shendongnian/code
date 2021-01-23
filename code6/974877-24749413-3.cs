    public ObjectUnderTest : IObjectUnderTest
    {
        private readonly IBusinessLogicObject businessLogicObject;
        public ObjectUnderTest(IBusinessLogicObject businessLogicObject)
        {
            businessLogicObject = businessLogicObject;
        }
        string IObjectUnderTest.MethodToBeTested(string businessLogicParam, string someOtherParam)
        {
            if ( someOtherParam == "businessLogic")
            {
                return businessLogicObject.SomeMethod(businessLogicParam);
            }
            return string.Empty;
        }
    }
  
