    [Cmdlet("Set", "PersistedVariables")]
    public class SetPersistedVariablesCmdlet : Cmdlet
    {
      [Parameter(ValueFromPipeline = true, Position = 0)]
      public string[] InputArray {get;set;}
      protected override void ProcessRecord()
      {
        var yourArray = InputArray;
      }
    }
