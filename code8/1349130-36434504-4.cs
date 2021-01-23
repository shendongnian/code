    public class ProxyB {
        ICtrlService service;
        public ProxyB(ICtrlService service) {
            this.service = service;
        }
    
        public List<MyObject> SomeProxyMethod() {
            var result = service.SomeMethod();    
            //...Do what you want with object
            return result;
        }
    }
