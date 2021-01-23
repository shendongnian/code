    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(_IContactManagerEvents))]
    [ComVisible(true)]
    public class MyContactManager : ContactManager
    {
      // Additional implementation details omitted.
    }
    
    
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    [ComSourceInterfaces(typeof(_IContactEvents))]
    public class MyOfficeContact : Contact 
    {
      // Additional implementation details omitted.
    }
    
    
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class MyAsyncOperation : AsynchronousOperation
    {
      // Additional implementation details omitted.
    }
