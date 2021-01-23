    public class Helper: IDisposable {
      private SqlConnection m_SqlConnection;
    
      // Note the absence of public "set"
      public SqlConnection SqlConnection {
        get {
          return m_SqlConnection; 
        } 
      }
      ...
    }  
