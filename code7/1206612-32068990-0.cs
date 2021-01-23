    public class SocialViewModels
    {
      public int ID { get; set; }
      public Nullable<bool> Rehber { get; set; }
      public int MarriageStatus { get; set; }
      public int Party { get; set; }
      public SelectList MarriageStatusList { get; set; }
      public SelectList partyList { get; set; }
    }
