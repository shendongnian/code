    [Serializable]
    public class Whatever
    {
         public Whatever()
         {
             //this always gets new-ed up, so there's no point in persisting it.
             //maybe it's not even serializable!
             HelperUtility = InitHelper();
         }
         //no sense in serializing this helper utility
         [NonSerialized]
         public NonSerializableClass HelperUtility;
        
         //but I may want to actually save this!
         public string DataIActuallyWantToSave;
    }
