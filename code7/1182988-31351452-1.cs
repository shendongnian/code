    public interface IGetString
    {
      string GetString();
    }
    public Chunk : IGetString
    {
      public string GetString()
      {
        return "MyContent";
      }
    }
    public class StringBuilderExtensions
    {
      public StringBuilder AppendFrom(this StringBuilder instance
        , IGetString getString)
      {
        instance.Append(getString.GetString())
        return instance;
      }
    }
