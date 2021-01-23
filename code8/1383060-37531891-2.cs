    [Cmdlet(VerbsData.Import, "SomethingElse")]
    public class ImportSomethingElse : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Description { get; set; }
        protected override void ProcessRecord()
        {
            Name = "new name";
            var outputVar = new SomeCustomClass { Name = Name, Description = Description}
            WriteObject(outputVar);
        }
    }
