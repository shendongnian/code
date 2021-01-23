    [TestClass]
    public class StudentHelperTests
    {
        private StudentHelper _objectToTest;
    
        private Mock<IUpdateStudentManager> _updateStudentManagerMock;
        private Mock<ISchedulerHelper> _schedulerHelperMock;
    
        [TestInitialize]
        public void Setup()
        {
            _updateStudentManagerMock = new Mock<IUpdateStudentManager>();
            _schedulerHelperMock = new Mock<ISchedulerHelper>();
    
            _studentHelperMock = StudentHelper(_updateStudentManagerMock.Object,
                _schedulerHelperMock.Object);
        }
    
        [TestMethod]
        public void Calling_GetEndDate_Returns_A_FutureDate()
        {
            // The method name says:
           var retrievedDate = _objectToTest.GetEndDate();
           Assert()//... And you should verify than the retrieved date is "a future date" 
        }
    }
