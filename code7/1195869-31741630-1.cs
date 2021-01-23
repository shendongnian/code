    public class MyController : UIViewController, IDisplayItem
    {
       // ...
    }
    
    public IDisplayItem CreateItemDisplayer()
    {
      return new MyController();
    }
