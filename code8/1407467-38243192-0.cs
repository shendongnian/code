    public class OuterService {
        private IService service;
        public OuterService(IService service) {
            this.service = service;
        }
        public void Notify(TestObject testObject) {
            service.SendNotification(testObject.Name, testObject, extraObject: null);
        }
    }
    public interface IService {
        void SendNotification(string name, TestObject testObject, object extraObject);
    }
    public class TestObject {
        public string Name { get; set; }
    } 
