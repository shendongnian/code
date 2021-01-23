    public class ExportPrsLiveReportJob : IJob
    {
        private readonly ISomeService _service;
        public ExportPrsLiveReportJob(ILogProvider logProvider, ISomeService service)
        {
            _service = service;
        }
        public ExportPrsLiveReportJob() : this(<however your system does dependency resolution for ILogProvider and ISomeService>){
        }
        public async void Execute(IJobExecutionContext context)
        {
            var data = await _service.Get();
        }
    }
