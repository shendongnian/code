    public class ProxyB {
        ICtrlService service;
        public ProxyB(ICtrlService service) {
            this.service = service;
        }
        public void SomeProxyMethod() {
            var temp = service.SomeMethod();
            //...Do what you want with object
        }
    }
