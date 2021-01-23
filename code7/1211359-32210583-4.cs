    public interface ISecurity
    {
      bool IsTest(string userName);
    }
    public sealed class Security : ISecurity
    {
      private static readonly Lazy<Security> lazy =
        new Lazy<Security>(() => new Security());
     
      public static ISecurity Security Instance { get { return lazy.Value; } }
 
      private Singleton()
      {
      }
      public bool IsTest(string userName)
      {
        
      }
    } 
