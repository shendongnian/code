    public interface IPublishable
    {
        PublishStatus Status { get; set; }
        DateTime? PublishDate { get; set; }
        DateTime? ExpireDate { get; set; }
    }
