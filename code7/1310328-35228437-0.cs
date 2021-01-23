    // The interface
    public interface IRecordIdEntity
    {
        int RecordId {get;set;}
    }
    
    // Sample Class
    public class Person : IRecordIdEntity
    {
       // implement the interface
       public int RecordId {get;set;} 
    }
    
    // Generic BulkDelete for IRecordIdEntitys
    public int BulkDelete<T>(MyDatabaseContext context, Expression<Func<T, bool>> predicate)
        where T : IRecordIdEntity
    {
        int rows = context.Set<T>().Where(predicate).Delete();
    
        return rows;
    }
    // Sample call
    BulkDelete<Person>(MyDatabaseContext, t=> deleteId.Contains(t.RecordId)) 
