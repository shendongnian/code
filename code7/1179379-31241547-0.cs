    public class GenericCriteria<T>
    {
         public List<Func<IQueryable<T>,IQueryable<T>>> 
              List { get; private set;}
         public GenericCriteria<T>(){
             List = new List<Func<IQueryable<T>,IQueryable<T>>>();
         }
    }
