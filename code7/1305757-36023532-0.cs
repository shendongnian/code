    var jobcred = new BasicAuthCredential();
            jobcred.UserName = "clusteruserid";
            jobcred.Password = "clusterpassword";
            jobcred.Server = new Uri("https://clusterurl");
     StreamingMapReduceJobCreateParameters jobpara = new StreamingMapReduceJobCreateParameters()
            {
                JobName="mapreduce",
                Mapper = "Mapper.exe",
                Reducer = "Reducer.exe",
                Input= "wasb:///mydata/input",
                Output = "wasb:///mydata/Output",
                StatusFolder= "wasb:///mydata/sOutput"
            };
            jobpara.Files.Add("wasb:///mydata/Mapper.exe");
            jobpara.Files.Add("wasb:///mydata/Reducer.exe");
     // Create a Hadoop client to connect to HDInsight.
            var jobClient = JobSubmissionClientFactory.Connect(jobcred);
            
            // Run the MapReduce job.
            JobCreationResults mrJobResults = jobClient.CreateStreamingJob(jobpara);
            
            // Wait for the job to complete.
            Console.Write("Job running...");
            JobDetails jobInProgress = jobClient.GetJob(mrJobResults.JobId);
            while (jobInProgress.StatusCode != JobStatusCode.Completed
              && jobInProgress.StatusCode != JobStatusCode.Failed)
            {
                Console.Write(".");
                jobInProgress = jobClient.GetJob(jobInProgress.JobId);
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            // Job is complete.
            Console.WriteLine("!");
            Console.WriteLine("Job complete!");
            Console.WriteLine("Press a key to end.");
            Console.Read();
