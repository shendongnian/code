    public abstract class WebObject : IReadable {
      protected void SetTextImpl() { /* Implementation */ } 
      protected void GetTextImpl() { /* Implementation */ } 
      // Implement IReadable -- this could be combined with GetTextImpl() but
      // is implemented separately for consistency.
      public void GetText() { GetTextImpl(); }
    }
    public class TextBox: WebObject, IWriteable {
      public void SetText() { SetTextImpl(); }
    }
    public class Span: WebObject, IReadable {
    }
