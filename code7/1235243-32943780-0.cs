    public class MyObject : ISerializable
    {
      private bool somemember;
    
      protected Complaint(SerializationInfo info, StreamingContext context)
      {
        somemember = info.GetBoolean("b");
      }
    
      [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
      public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
      {
        info.AddValue("b", somemember);
      }
    }
