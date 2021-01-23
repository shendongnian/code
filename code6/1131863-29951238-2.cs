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
       public void Update(FinalClass finalClassInstance) { }; //Updates everything
       public void Update(ICommonProperties finalClassInstance) { }; //Updates only ICommonProperties
       public void Update(ITrackable finalClassInstance) { }; //updates only Status.
    }
