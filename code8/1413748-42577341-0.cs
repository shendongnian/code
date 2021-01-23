    public class TypeWithImplementOne : IMyInterface
    {
      public string Hi()
      {
        return "hi";
      }
    }
    public class TypeWithImplementTwo : IMyInterface
    {
       public string Hi()
      {
        return "hi";
      }
    }
    public interface IMyInterface{
    {
      [ServiceKnownType(typeof(TypeWithImplementOne))]
      [ServiceKnownType(typeof(TypeWithImplementTwo))]
      string Hi();
    }
