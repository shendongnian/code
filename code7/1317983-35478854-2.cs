    using ServiceReference1;
    public class ServiceTestClass
    {
        public ServiceTestClass()
        {
            using (var client = new LearningStatusRecordsPortTypeClient())
            {
                client.FetchLearningStatusRecords(
               new LearningStatusRecordsFetchRequest());
                client.AcknowledgeLearningStatusRecords(
                    new LearningStatusRecordsAcknowledgeRequest());
            }
        }
    }
