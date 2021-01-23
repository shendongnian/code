    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public class DataParamAttribute : Attribute
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name { get; set; }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="DataParamAttribute"/> class.
            /// </summary>
            /// <param name="name">
            /// The name.
            /// </param>
            public DataParamAttribute(string name)
            {
                this.Name = name;
            }
        }
