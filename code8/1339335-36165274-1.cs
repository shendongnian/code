    public override void SubmitChanges(ConflictMode failureMode)
    {
        ExecuteQuery<object>("SET NOCOUNT OFF");
        base.SubmitChanges(failureMode);
    }
