    class Properties
    {
        private List<Assembly> assemblies = new List<Assembly>();
        [DisplayName("ExpectedAssemblyVersions")]
        [Description("The expected assembly versions.")]
        [Category("Mandatory")]
        [Editor(typeof(CollectionEditor), typeof(CollectionEditor))]
        public List<Assembly> Assemblies
        {
            get
            {
                return assemblies;
            }
            set
            {
                assemblies = value;
            }
        }
    }
    class Assembly
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
