    %module test
    
    %pragma(csharp) moduleclassmodifiers=%{
    // Custom C# Exception
    public class CustomApplicationException : global::System.ApplicationException {
      public CustomApplicationException(string message)
        : base(message) {
      }
    }
    
    public class%}
