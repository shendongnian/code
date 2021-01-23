    [Cmdlet(VerbsCommon.Get, "Test", DefaultParameterSetName = "Path")]
    public sealed class GetTestCommand : PSCmdlet
    {
        private FileSystemInfo[] _paths;
        [Parameter(
          ParameterSetName = "Path",
          Mandatory = true,
          Position = 0,
          ValueFromPipeline = true,
          ValueFromPipelineByPropertyName = true
        )]
        public FileSystemInfo[] Path
        {
            get { return _paths; }
            set
            {
                _paths = value;
            }
        }
        protected override void ProcessRecord()
        {
            ProviderInfo pi;
            (from p in _paths
             where (p.GetType() != typeof(DirectoryInfo))
             select new
             {
                 FilePath = p.FullName}).ToList()
            .ForEach(i => WriteObject(i.FilePath));
        }
    }
