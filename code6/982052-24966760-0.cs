    public interface IUploadedFilebase
    {
        string CaseId { get; }
        string ChargeReference { get; }
        Double Amount { get; }
        DateTime ReceivedDate { get; }
        string ReasonCode { get; }
        string ReplyBy { get; }
        string Resolution { get; }
        Double ChargeAmount { get; }
    }
