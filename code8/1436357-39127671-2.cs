    public enum RequestStatus : byte
    {
      Processing, Handled
    }
    
    public class Request
    {
      public RequestStatus Status { get; set; }
    }
    public void ExitMethod(Request request) => // ...
    public void SomeMethod(Request request)
    {
      ExitMethod();
      if (request.Status == Handled) return;
      Console.WriteLine("Test");
    }
