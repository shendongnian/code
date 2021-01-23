'Try QueueARN which is something like this arn:aws:sqs:region:account-id:queuename '
     namespace Amazon.SQS.Model
    {
       public class GetQueueAttributesResult : AmazonWebServiceResponse
       {
        public GetQueueAttributesResult();
        public int ApproximateNumberOfMessages { get; }
        public int ApproximateNumberOfMessagesDelayed { get; }
        public int ApproximateNumberOfMessagesNotVisible { get; }
        public Dictionary<string, string> Attributes { get; set; }
        public DateTime CreatedTimestamp { get; }
        public int DelaySeconds { get; }
        public DateTime LastModifiedTimestamp { get; }
        public int MaximumMessageSize { get; }
        public int MessageRetentionPeriod { get; }
        public string Policy { get; }
        public string QueueARN { get; }
        public int VisibilityTimeout { get; }
       }
    }
