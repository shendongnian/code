    public interface IBaz
    {
    }
    
    public class Foo : IBaz
    {
                
    }
    
    public class Bar : IBaz
    {
                
    }
    
    public static void MySetup(DurianContext context, Action<DurianContext, List<IBaz>> addMethod)
    {            
        List<IBaz> list1 = new List<IBaz>();
        addMethod(context, list1);
    
        List<IBaz> list2 = new List<IBaz>();
        addMethod(context, list2);
    }
