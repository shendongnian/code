    [Cmdlet(VerbsCommon.Get, "Something")]
    public class GetSomething : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var SomeCustomObject = new SomeCustomClass
            { Name = "some name", Description = "some description" };
            WriteObject(SomeCustomObject);
        }
    }
    [Cmdlet(VerbsData.Import, "Something")]
    public class ImportSomething : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public SomeCustomClass SomeCustomObject { get; set; }
        protected override void ProcessRecord()
        {
            SomeCustomObject.Name = "new name"; // modify the input object--bad!
            WriteObject(SomeCustomObject);
        }
    }
