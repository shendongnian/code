     interface ICustomRequired
     {
     }
     class ImplementationOne : ICustomRequired
     {
     }
     class ImplementationTwo: ICustomRequired
     {
     }
     var listOne = new List<ImplementationOne>();
     var castReference = listOne as List<ICustomRequired>();
     // Because you did a cast, the two instances would point
     // to the same implementation
     // Now watch me screw things up
     castReference.Add(new ImplementationTwo());
 
     // listOne was supposed to be a list of ImplementationOne objects,
     // but I just managed to insert an object of a different type
      
