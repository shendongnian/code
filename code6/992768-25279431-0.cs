    using System.Linq;
    // ..
    static List<T> Shared<T>(params List<T>[] lists)
    {
        if (lists == null)
        {
            throw new ArgumentNullException("lists");
        }  
      
        return Shared(lists.ToList());
    }
