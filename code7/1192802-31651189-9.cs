    public class JobListService : IListService<Job>
    {
        // Your generated service
        private readonly JobList_Service _service;
        ... // set up service in ctor or wherever
        public Job[] ReadMultiple()
        {
            return _service.ReadMultiple();
        }
    }        
