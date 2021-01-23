    public class UILayerController
    {
     // Here either you can use the Property injection
     public IBusinessObj MyBusinessStuff {get; set ;}
     
     // OR
     //you can use the constructor injection with private field 
     private IBusinessObj  _myBusinessStuff
     public UILayerController(IBusinessObj  myBusinessStuff)
     {
      _myBusinessStuff = myBusinessStuff;
     }
    }
