    public interface IMetaDataHolder{
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset ModifiedDate { get; set; }
        AppUser CreatedBy { get; set; }
        AppUser ModifiedBy { get; set; }
    }
