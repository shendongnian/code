    /// <summary>
    /// Provides a managed interface to access Model Services
    /// </summary>
    /// <typeparam name="TServiceType">The Type of the parameter to be managed</typeparam>
    public class ServiceHandle<TServiceType> : IServiceHandle<TServiceType> where TServiceType : IService
    {
        static private readonly ILog Log = LogManager.GetLogger(typeof(ServiceHandle<TServiceType>));
        private readonly ILifetimeScope _scope;
        /// <summary>
        /// True if there where Exceptions caught during the last Invoke execution.
        /// </summary>
        public bool ErrorCaught { get; private set; }
        /// <summary>
        /// List of the errors caught during execution
        /// </summary>
        public List<String> ErrorsCaught { get; private set; }
        /// <summary>
        /// Contains the exception that was thrown during the
        /// last Invoke execution.
        /// </summary>
        public Exception ExceptionCaught { get; private set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="scope">The current Autofac scope</param>
        public ServiceHandle(ILifetimeScope scope)
        {
            if (scope == null)
                throw new ArgumentNullException("scope");
            _scope = scope;
            ErrorsCaught = new List<String>();
        }
        /// <summary>
        /// Invoke a method to be performed using a 
        /// service instance provided by the ServiceHandle
        /// </summary>
        /// <param name="command">
        /// Void returning action to be performed
        /// </param>
        /// <remarks>
        /// The implementation simply wraps the Action into
        /// a Func returning an Int32; the returned value
        /// will be discarded.
        /// </remarks>
        public void Invoke(Action<TServiceType> command)
        {
            Invoke(s =>
            {
                command(s);
                return 0;
            });
        }
        /// <summary>
        /// Invoke a method to be performed using a 
        /// service instance provided by the ServiceHandle
        /// </summary>
        /// <typeparam name="T">Type of the data to be returned</typeparam>
        /// <param name="command">Action to be performed. Returns T.</param>
        /// <returns>A generically typed T, returned by the provided function.</returns>
        public T Invoke<T>(Func<TServiceType, T> command)
        {
            ErrorCaught = false;
            ErrorsCaught = new List<string>();
            ExceptionCaught = null;
            T retVal;
            try
            {
                using (var serviceScope = GetServiceScope())
                using (var service = serviceScope.Resolve<TServiceType>())
                {
                    try
                    {
                        retVal = command(service);
                        service.CommitSessionScope();
                    }
                    catch (RollbackException rollbackEx)
                    {
                        retVal = default(T);
                        if (System.Web.HttpContext.Current != null)
                            ErrorSignal.FromCurrentContext().Raise(rollbackEx);
                        Log.InfoFormat(rollbackEx.Message);
                        ErrorCaught = true;
                        ErrorsCaught.AddRange(rollbackEx.ErrorMessages);
                        ExceptionCaught = rollbackEx;
                        DoRollback(service, rollbackEx.ErrorMessages, rollbackEx);
                    }
                    catch (Exception genericEx)
                    {
                        if (service != null)
                        {
                            DoRollback(service, new List<String>() { genericEx.Message }, genericEx);
                        }
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.Web.HttpContext.Current != null)
                    ErrorSignal.FromCurrentContext().Raise(ex);
                var msg = (Log.IsDebugEnabled) ?
                    String.Format("There was an error executing service invocation:\r\n{0}\r\nAt: {1}", ex.Message, ex.StackTrace) :
                    String.Format("There was an error executing service invocation:\r\n{0}", ex.Message);
                ErrorCaught = true;
                ErrorsCaught.Add(ex.Message);
                ExceptionCaught = ex;
                Log.ErrorFormat(msg);
                retVal = default(T);
            }
            return retVal;
        }
        /// <summary>
        /// Performs a rollback on the provided service instance
        /// and records exception data for error retrieval.
        /// </summary>
        /// <param name="service">The Service instance whose session will be rolled back.</param>
        /// <param name="errorMessages">A List of error messages.</param>
        /// <param name="ex"></param>
        private void DoRollback(TServiceType service, List<string> errorMessages, Exception ex)
        {
            var t = new Task<string>
            service.RollbackSessionScope();
        }
        /// <summary>
        /// Creates a Service Scope overriding Session resolution:
        /// all the service instances share the same Session object.
        /// </summary>
        /// <returns></returns>
        private ILifetimeScope GetServiceScope()
        {
            return _scope.BeginLifetimeScope("service");
        }
    }
