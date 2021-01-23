    %module test
    
    %pragma(csharp) modulecode=%{
    // Custom C# Exception
    public class CustomApplicationException : global::System.ApplicationException {
      public CustomApplicationException(string message)
        : base(message) {
      }
    }
    %}
