        private const string TEST_METHOD_UNIQUE_NAME_PART = "test";
        private static TestContext _testContext;
        private static bool _isPreconditionCompleted;
        private static int _numberOfCompletedTests;
        private int NumberOfTestMethodsInClass
        {
            get
            {
                var className = _testContext.FullyQualifiedTestClassName.Split('.').Last().Trim();
                var currentType = Assembly.GetExecutingAssembly().GetExportedTypes()
                                 .Where(r => r.Name.Trim() == className).First();
                return currentType.GetMethods().Where(r => r.Name.ToLower()
                      .Contains(TEST_METHOD_UNIQUE_NAME_PART)).Count();
            }
        }
        [ClassInitialize]
        public static void ClassSetUp(TestContext testContext)
        {
            _testContext = testContext;
            _isPreconditionCompleted = false;
            _numberOfCompletedTests = 0;
        }
        [TestInitialize]
        public void SetUp()
        {
            if (!_isPreconditionCompleted)
            {
                PreConditionMethod();
            }
        }
        [TestCleanup]
        public void TearDown()
        {
            _numberOfCompletedTests++;
            if (_numberOfCompletedTests == NumberOfTestMethodsInClass)
            {
                PostConditionMethod();
            }
        }
        private void PreConditionMethod()
        {
            // Your code
            _isPreconditionCompleted = true;
        }
        private void PostConditionMethod()
        {
            // Your code
        }
