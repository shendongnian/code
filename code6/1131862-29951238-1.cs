    public interface ICommonProperties
    {
       public string P1{get; set;}
       public string P2{get; set;}
       public string P3{ get; set; }
    }
    public interface ITrackable
    {
       public string Status{get; set;}
    }
    public class FinalClass : ICommonProperties, ITrackable
    {
       public string P1{get; set;}
       public string P2{get; set;}
       public string P3{get; set;}
       public string Status{get; set;}
    }
    
    public class FinalClassOperations
    {
       private void Update(FinalClass finalClassInstance) { }; //Updates everything
       private void Update(ICommonProperties finalClassInstance) { }; //Updates only ICommonProperties
       private void Update(ITrackable finalClassInstance) { }; //updates only Status.
    }
