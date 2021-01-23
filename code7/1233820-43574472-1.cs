    public class MyClass{
    
    public enum myEnumType {
    FedEx,
    Olther
    } 
    
    public int id {get;set;}
    public myEnumType Supplier {get;set;}
    }
    //My class Map (using Fluent...)    
    public class MyClassMap {
    HasKey(t => t.Id);
    Property(t => t.Id).HasColumnName("Id");
    //The type [supplier] should be [int] in database.
    Property(t => t.Supplier).HasColumnName("supplier");
    //That's all, you don't need write relationship, int this case 
    //Because, when the data returns, the EF will to do the conversion for you.
    }
     
