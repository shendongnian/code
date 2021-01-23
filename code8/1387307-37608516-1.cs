    public class QuestionSenderJob: IJob
    {
        public void Execute(JobExecutionContext context)
        {            
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            // Extract question Id and send message
        }
    }
