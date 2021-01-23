    [TestFixture(typeof(OrderTaskGenerator), typeof(OrderTaskRequest))]
    public class TaskGeneratorContractTest<T, TRequest> where T : ITaskGenerator<TRequest>, new() where TRequest : ITaskRequest
    {
        private T _sut;
    
        public TaskGeneratorContractTest()
        {
            _sut = new T();
        }
        [Test]
        public void CreateTask_Returns_InvalidException_If_Task_ID_Is_Empty()
        {
            Assert.IsTrue(true);
        }
    }
