    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
         public int Calculate
         {
            get { return CalculatedValue;}
            set { CalculatedValue = value +1;}
         }
    }
