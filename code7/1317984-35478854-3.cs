    using ServiceReference1;
    public class ServiceTestClass
    {
        public ServiceTestClass()
        {
            using (var client = new LearningStatusRecordsPortTypeClient())
            {
                 LearningStatusRecordsFetchResponse result1 = client.FetchLearningStatusRecords(
               new LearningStatusRecordsFetchRequest());
                   foreach (LearningStatusRecord lsr in result1.LearningStatusRecordsList)
                    {
                        Console.WriteLine(lsr.RecordStatus);
                    }
               LearningStatusRecordsAcknowledgeResponse result2 =  client.AcknowledgeLearningStatusRecords(
                    new LearningStatusRecordsAcknowledgeRequest());
            }
        }
    }
