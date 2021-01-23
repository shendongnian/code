    class Command1 : BaseCommand
        {
            public Command1(MultiCommand rollbackMultiCommand = null) : base(rollbackMultiCommand)
            {
            }
    
            protected override bool ExecuteAction()
            {
                Output("command 1 executed");
                return true;
            }
            
            public override void Rollback()
            {
                Output("command 1 canceled");
            }
        }
