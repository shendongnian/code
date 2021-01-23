    /// <summary>
    /// An activator that uses <see cref="SimpleInjector"/> to return instance of a job type.
    /// </summary>
    public class SimpleInjectorJobActivator : IJobActivator
    {
        /// <summary>
        /// Gets or sets the container to resolve dependencies.
        /// </summary>
        private readonly Container _container;
        /// <summary>
        /// Initialize a new instance of the <see cref="SimpleInjectorJobActivator"/> class.
        /// </summary>
        /// <param name="container">The <see cref="Container"/> to resolve dependencies.</param>
        public SimpleInjectorJobActivator(Container container)
        {
            _container = container;
        }
        /// <summary>
        /// Creates a new instance of a job type.
        /// </summary>
        /// <typeparam name="T">The job type.</typeparam>
        /// <returns>
        /// A new instance of the job type.
        /// </returns>
        public T CreateInstance<T>()
        {
            return (T)_container.GetInstance(typeof(T));
        }
    }
