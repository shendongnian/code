        public CreateJobResponse Post(CreateJobRequest request)
        {
            return BusProxy.Call<CreateJobRequest, CreateJobResponse>(request);
        }
        public GetJobResponse Get(int id)
        {
            return BusProxy.Call<GetJobRequest, GetJobResponse>(id);
        }
