    public interface ITrackableEntity
    {
      DateTime CreatedDateTime { get; set; }
      int CreatedUserID { get; set; }
      DateTime ModifiedDateTime { get; set; }
      int ModifiedUserID { get; set; }
    }
