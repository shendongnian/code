    /// <summary>
    /// Creates an IMyDataContext instance
    /// </summary>
    public static class MyDataContextFactory
    {
        /// <summary>
        /// The factory used to create an instance
        /// </summary>
        static Func<IMyDataContext> factory;
        /// <summary>
        /// Initializes the specified creation factory.
        /// </summary>
        /// <param name="creationFactory">The creation factory.</param>
        public static void SetFactory(Func<IMyDataContext> creationFactory)
        {
            factory = creationFactory;
        }
        /// <summary>
        /// Creates a new IMyDataContext instance.
        /// </summary>
        /// <returns>Returns an instance of an IMyDataContext </returns>
        public static IMyDataContext CreateContext()
        {
            if (factory == null) throw new InvalidOperationException("You can not create a context without first building the factory.");
            return factory();
        }
    }
