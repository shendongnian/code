    [Cmdlet("Use", "Dummy")]
    public class UseDummyCmdlet :PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var errorRecord = new ErrorRecord(new Exception("Something Happened"), "SomethingHappened", ErrorCategory.CloseError, null);
            try
            { 
                 ThrowTerminatingError(errorRecord);
            }
            catch (PipelineStoppedException ex)
            {}
        }
    }
