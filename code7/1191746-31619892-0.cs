    public abstract class BehaviorClass<TBehavior, TDomainObj>
        where TBehavior : BehaviorClass<TBehavior, TDomainObj> 
        where TDomainObj : IDomainObj
    {
      protected BehaviorClass(var x){...}
      public abstract void Create(List<T> list, out string message);
      public abstract void Delete(List<T> list, out string message);
      ...
      public static void Import()
      {
        var instance = (DbObj)Activator.CreateInstance(typeof(TBehavior), DbAccessor);
        // STEP 1: Remove existing values
        var existingValues = instance.Read();
        instance.Delete(existingValues, out message);
        // STEP 2: Create new IDomainObjects 
        var domainObjects = //LINQ Query.ToList();
        // STEP 3: Add new IDomainObjects to the instance
        instance.Create(domainObjects, message);
      }
    }
