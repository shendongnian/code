    public class MyFakeHeaderService : IHeaderService {
        string os;
        public MyFakeHeaderService(string os) {
            this.os = os;
        }
    
        public string GetOsType() {
            return os;
        }
    }
