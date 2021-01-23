            public async Task<IHttpActionResult> GetJobInfo(int jobId)
        {
            try
            {
                JobModel a = new JobModel { name = "jobA", ID = 102, completion = 100.0f };
                JobModel b = new JobModel { name = "jobB", ID = 104, completion = 42.0f };
                JobModel c = new JobModel { name = "jobC", ID = 106, completion = 0.0f };
                List<JobModel> result = new List<JobModel> { a, b, c };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        public async Task<IHttpActionResult> SubmitJob([FromBody] JobModel submitedJob)
        {
            return Ok();
        }
