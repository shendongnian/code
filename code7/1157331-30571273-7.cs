    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
         private int _calculated;
         public int Calculated
         {
            get { return _calculated;}
            set { _calculated = value +1;}
         }
    }
