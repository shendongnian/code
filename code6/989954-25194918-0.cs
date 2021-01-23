    [ServiceContract]
    public interface IService {
      [OperationContract]
      int GetMyIndex();
      [OperationContract]
      void AnyOtherMethod(string foo, int clientIndex);
    }
    public class Service : IService {
      static int m_Counter;
      static object m_SyncRoot = new object();
      public int GetMyIndex() {
        lock (m_SyncRoot) {
          m_Counter++;
          return m_Counter;
        }
      }
      public void AnyOtherMethod(string foo, int clientIndex) {
        // do something
      }
    }
