    public sealed class RightsChecker
    {
        readonly IRightsService service;
        public RightsChecker(IRightsService service)
        {
            this.service = service;
        }
        public void CheckRights()
        {
            if (!service.UserHasRights())
            {
                EnvironmentControl.Current.Exit(1);
            }
        }
    }
