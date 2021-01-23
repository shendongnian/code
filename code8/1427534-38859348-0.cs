        public enum ManagerType
        {
            A,B
        }
    
        public abstract class UDPManager
        {
            
        }
    
        public class SomethingA : UDPManager
        {
            public void A()
            {}
        }
    
        public class SomethingB : UDPManager
        {
            public void B()
            {}
        }
    
        public class UdpManagerFactory
        {
            public UDPManager Build(ManagerType type)
            {
                if (type == ManagerType.A)
                    return new SomethingA();
    
                if(type == ManagerType.B)
                    return new SomethingB();
    
                throw new Exception("type not found");
            }
        }
