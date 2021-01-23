    public interface IAppendOnly
    {
      void Append(string content);
    }
    public class AppendOnlyStringBuilder : IAppendOnly
    {
      private StringBuilder _stringBuilder = new StringBuilder()
      public void Append(string content)
      {
        _stringBuilder.Append(content);
      }
      public override string ToString()
      {
        return _stringBuilder.ToString();
      }
    }
  
    public class Chunk
    {
      public void AppendTo(IAppendOnly appendOnly)
      {
        appendOnly.Append("My Content");
      }
    }
