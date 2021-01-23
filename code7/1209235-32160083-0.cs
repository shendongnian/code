    [KnownType(typeof(List<objFABusinessActivity>))]
    public class YourDtoClass
    {
       [DataMember]
       public List<objFABusinessActivity> BAList
       {
         get
         {
            if (_baList == null)
            {
                _baList = new List<objFABusinessActivity>();
             }
             return _baList;
         }
         set 
         {
                _baList = (value != null) ? new List<objFABusinessActivity>(value) : new List<objFABusinessActivity>();
         }
       }
    }
