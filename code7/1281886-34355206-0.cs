    public Interface IHidable
    {
        bool hidden;
    }
    
    public class MyModel : IHidable , ...
    {
        
    }
    
    private Collection<MyModel> realCoollection;  //use this for anything else
    public Collection<IHidable > viewCollection  //Bind this in your WPF
    {
      get {
         Collection<IHidable>  resCollection = new Collection<IHidable>();
         foreach (MyModel item in realCoollection)
         {            
            if (!item.hidden) res.Add((IHidable)item)
         }
         return resCollection;
       }
    }
