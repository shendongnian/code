    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
         private int _calculated;
         public int Calculated
         {
            get { return UserId + 1;}
            set { _calculated = value +1}
         }
    }
