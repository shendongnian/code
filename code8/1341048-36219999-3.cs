    /// <summary>
    /// Injectable DateTime interface, should be used to ensure date specific logic is more testable
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Current Data time
        /// </summary>
        DateTime Now { get; }
    }
    /// <summary>
    /// DateTime.Now - use as concrete implementation
    /// </summary>
    public class SystemDateTime : IDateTime
    {
        /// <summary>
        /// DateTime.Now
        /// </summary>
        public DateTime Now { get { return DateTime.Now; } }
    }
    /// <summary>
    /// DateTime - used to unit testing functionality around DateTime.Now (externalizes dependency on DateTime.Now
    /// </summary>
    public class MockSystemDateTime : IDateTime
    {
        private readonly DateTime MockedDateTime;
        /// <summary>
        /// Take in mocked DateTime for use in testing
        /// </summary>
        /// <param name="mockedDateTime"></param>
        public MockSystemDateTime(DateTime mockedDateTime)
        {
            this.MockedDateTime = mockedDateTime;
        }
        /// <summary>
        /// DateTime passed from constructor
        /// </summary>
        public DateTime Now { get { return MockedDateTime; } }
    }
