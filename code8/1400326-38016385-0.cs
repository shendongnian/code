    [DataContract]
    public class GenericSample<TGeneric>
    {
         private TGeneric id;
         
         [DataMember]
         public TGeneric Id 
         {
              get { return id; }
              set { id = value; }
         }
    }
