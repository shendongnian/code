       public void ExecQueryIntoTable(string projectId, string dataSetId, string destinationTable, string query)
        {
            try
            {
                JobsResource jobResource = bigqueryService.Jobs;
                Job theJob = new Job();
                theJob.Configuration = new JobConfiguration()
                {
                    Query = new JobConfigurationQuery()
                    {
                        AllowLargeResults = true,
                        CreateDisposition = "CREATE_IF_NEEDED",
                        DefaultDataset = new DatasetReference() { ProjectId = projectId, DatasetId = dataSetId},
                        MaximumBillingTier = 100,
                        DestinationTable = new TableReference() { ProjectId = projectId, DatasetId = dataSetId, TableId = destinationTable },
                        Query = query
                    }
                };
                var result = jobResource.Insert(theJob, projectId).Execute();
            }
            catch (Exception ex)
            {
                log.Fatal(ex, ex.Message + ", StackTrace: " + ex.StackTrace);
                throw;
            }
        }
