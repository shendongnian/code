    public IEnumerable<MyClass> GetThings(List<object> lst)
    {
      int ID=0;
      return from i in lst.Select((item,id)=>new {Item=item, ID=id})
             select new MyClass(i.ID, i.Item);
    }
    public class MyClass
    {
      public MyClass(int ID, object Stuff)
      { ... }
    }
    ...
      var x = GetThings(SomeList);
