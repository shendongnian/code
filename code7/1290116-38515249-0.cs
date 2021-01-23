    /// <summary>
    /// Test Logger. 
    /// </summary>
    /// <remarks>
    /// Build unit test code as follows:
    /// <code>
    /// using TestCommon;
    /// [TestClass]
    /// public class MyTestClass {
    /// 
    /// // This property & static MUST be inside your [TestClass]
    /// public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
    /// {   get { return context; }
    ///     set { context = value; } }
    /// private static TestContext context = null;
    /// private static TestLogger log = null;
    /// [ClassInitialize]
    /// public void Initialize() {
    ///     log = new TestLogger(logFileName);  // provide a path\name
    /// }
    /// 
    /// [TestMethod]
    /// public void MyTest()
    /// {
    ///     try {
    ///         log.Open(context);
    ///         ... // perform a test
    ///         log.Info("time: {0} Iteration {1}", Now, i);
    ///     } catch (AssertFailedException ex)
    ///         log.Exception(ex);
    ///         throw;
    ///     } finally {
    ///         log.Close();
    ///     }
    /// }
    /// </code>
    /// </remarks>
    public class TestLogger
    {
        private static TestContext context = null;
        private string logfilename = null;
        private TextWriterTraceListener writer = null;
        private DataCollectorMessageLevel errorLevel = DataCollectorMessageLevel.Info;
        /// <summary>
        /// Microsoft.VisualStudio.TestTools.Common.DataCollectorMessageLevel
        /// Levels: Error, Warning, Info (default), Data
        /// </summary>
        public DataCollectorMessageLevel ErrorLevel
        {
            get { return errorLevel; }
            set { errorLevel = value; }
        }
        /// <summary>
        /// Create the logger. Set up work in Class initializer, it should also work inside each test.
        /// </summary>
        /// <param name="logfile">Path to the file to log into</param>
        public TestLogger(string logfile, bool update = true)
        {
            logfilename = logfile;
            errorLevel = DataCollectorMessageLevel.Info;
            if (!update)
                try { System.IO.File.Delete(logfile); } catch { }
            writer = new TextWriterTraceListener(logfilename);
            Debug.Listeners.Add(writer);
            Debug.AutoFlush = true;
            if (context != null)
            {
                Debug.WriteLine("Test Logger: {0} - {1}", context.FullyQualifiedTestClassName, context.TestName);
            }
        }
        /// <summary>
        /// At start of a test, it logs that information
        /// </summary>
        /// <param name="theContext">records context to access Test Name</param>
        public void Open(TestContext theContext)
        {
            context = theContext;
            Debug.WriteLine("Test Logger: {0} - {1}", context.FullyQualifiedTestClassName, context.TestName);
        }
        /// <summary>
        /// At end of a test. Best if put in a finally clause.
        /// </summary>
        public void Close()
        {
            if (context != null)
            {
                Debug.WriteLine("Test Ending: {0} - {1}", context.FullyQualifiedTestClassName, context.TestName);
            }
            Debug.WriteLine("");
        }
        /// <summary>
        /// The Logger functions use a standard string format 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public void Data(string format, params object[] parameters)
        {
            if (errorLevel > DataCollectorMessageLevel.Data) return;
            Debug.WriteLine(format, parameters);
        }
        public void Info(string format, params object[] parameters)
        {
            if (errorLevel > DataCollectorMessageLevel.Info) return;
            Debug.WriteLine(format, parameters);
        }
        public void Warning(string format, params object[] parameters)
        {
            if (errorLevel > DataCollectorMessageLevel.Warning) return;
            Debug.WriteLine(format, parameters);
        }
        public void Error(string format, params object[] parameters)
        {
            if (errorLevel > DataCollectorMessageLevel.Error) return;
            Debug.WriteLine(format, parameters);
        }
        /// <summary>
        /// Able to include the Assert error message in the log
        /// </summary>
        /// <param name="ex">ex.Message is the Assert message, ex.ToString includes the call stack</param>
        public void Exception(Exception ex)
        {
            if (ex is AssertFailedException)
            {
                // ex.Message is only the Assertion text
                Debug.WriteLine(String.Format("{0}", ex.ToString()));
            }
            else
            {
                Debug.WriteLine(string.Format("{0}", ex.ToString()));
            }
        }
    }
