    public class TextBox: WebObject, IWriteable, IReadable {
      public void SetText() { SetTextImpl(); }
      public void GetText() { GetTextImpl(); }
    }
    public class Span: WebObject, IReadable {
      public void GetText() { GetTextImpl(); }
    }
