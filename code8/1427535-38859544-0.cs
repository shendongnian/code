    public interface IUdpManagerA
    {
        void A();
    }
    
    public interface IUdpManagerB
    {
        void B();
    }
    public class UdpManager : IUdpManagerA, IUdpManagerB
    {
        public void A() { }
        public void B() { }             
    }
    public class UdpManagerFactory
    {
         private UdpManager Create() => new UdpManager();
         public IUdpManagerA CreateOfA() => Create();
         public IUdpManagerB CreateOfB() => Create();
    }
    UdpManagerFactory factory = new UdpManagerFactory();
    IUdpManagerA a = factory.CreateOfA();
    IUdpManagerB b = factory.CreateOfB();
