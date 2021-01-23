    public class MonitorSubmissionFeedSagaData: IContainSagaData
    {
    public Guid Id { get; set; }
    public string Originator { get; set; }
    public string OriginalMessageId { get; set; }
    
    [Unique]
    public string JobId { get; set; }
	public DateTime SagaStartTimeUtc { get; set; }
    }
    public class MonitorSubmissionFeedSaga : Saga<MonitorSubmissionFeedSagaData>,
        IAmStartedByMessages<MonitorFeedSubmissonCommand>,
        IHandleTimeouts<VerifyApiTimeOut>
    {
    public IEmpathyBrokerClientApi PostFileService { get; set; }
    public void Handle(MonitorFeedSubmissonCommand message)
    {
        Data.JobId = message.JobId;
		Data.SagaStartTimeUtc = DateTime.NowUtc;
		
        CreateTimeoutRequest();
    }
    public void CreateTimeoutRequest()
    {
        RequestTimeout<VerifyApiTimeOut>(TimeSpan.FromSeconds(30));
    }
    public void Timeout(VerifyApiTimeOut state)
    {
        if (!GetJobStatus(Data.JobId) && DateTime.NowUtc < Data.SagaStartTimeUtc.AddMinutes(60))
		{
		  CreateTimeoutRequest();
		}
		
		MarkAsComplete();
    }
    bool GetJobStatus(string jobId)
    {
        return false;
        var status = PostFileService.GetJobIdStatus(jobId);
        if (status.state == "FAILURE" || status.state == "DISCARDED")
        {
            return false;
        }
        return true;
    }
    }
