    public class UsingClass
    {
        IConstantClass constants;
        public UsingClass(){
             constants f = new FactoryConstants();
        }
    }
    public class FactoryConstant
    {
       public FactoryConstant()
       {
       }
       public IConstantClass GetConstant()
       {
           #if DEBUG
           return new ConstantsDebugMode();
           #else
           return new ConstantsProduction();
           #endif
       }
    }
    public interface IConstantClass
    {
       public string FIELDAAA {get;set;}
       public string FIELDBBB {get;set;}
    } 
    public class ConstantsProduction : IConstantClass
    {
       public string FIELDAAA
       {
           get { return "ProductionString"; }
           set { }
       }
       public string FIELDBBB
       {
           get { return "ProductionString2"; }
           set { }
       }
    }
    public class ConstantsDebugMode : IConstantClass
    {
       public string FIELDAAA
       {
           get { return "ReallyLongStringDebugMode"; }
           set { }
       }
       public string FIELDBBB
       {
           get { return "ReallyLongStringDebugMode2222"; }
           set { }
       }
    }
