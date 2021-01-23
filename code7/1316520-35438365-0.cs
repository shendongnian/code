        public DependencyAttribute()
            : this(null) { }
        /// <summary>
        /// Create an instance of <see cref="DependencyAttribute"/> with the given name.
        /// </summary>
        /// <param name="name">Name to use when resolving this dependency.</param>
        public DependencyAttribute(string name)
        {
            this.name = name;
        }
