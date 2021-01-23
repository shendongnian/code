    /// <summary>
    /// Allows to working with class as singleton.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class, new()
    {
        /// <summary>
        /// Gets the sole instance.
        /// </summary>
        /// <value>The instance.</value>
        static T Instance
        {
            get { return InternalContainer.Instance; }
        }
        /// <summary>
        /// Internal instance that guaranties sole instantination.
        /// </summary>
        private class InternalContainer
        {
            /// <summary>
            /// The sole instance.
            /// </summary>
            public static readonly T Instance;
            /// <summary>
            /// Initializes the <see cref="Singleton&lt;T&gt;.InternalContainer"/> class.
            /// </summary>
            static InternalContainer()
            {
                Instance = new T();
            }
        } 
    }
