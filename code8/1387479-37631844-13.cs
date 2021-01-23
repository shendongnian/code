    class FailCommand : BaseCommand
        {
            public FailCommand(MultiCommand rollbackMultiCommand = null) : base(rollbackMultiCommand)
            {
            }
    
            protected override bool ExecuteAction()
            {
                Output("failed command executed");
                return false;
            }
    
            public override void Rollback()
            {
                Output("failed command cancelled");
            }
        }
