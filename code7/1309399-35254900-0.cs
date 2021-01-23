    internal interface IApplicationProvider
    {
        Excel.Application CurrentApplication { get; }
    }
    class ApplicationProvider : IApplicationProvider
    {
        public ApplicationProvider(Excel.Application application)
        {
            this.CurrentApplication = application;
        }
        // c# 6 syntax
        public Excel.Application CurrentApplication { get; } 
    }
