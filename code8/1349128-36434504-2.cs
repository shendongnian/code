    public interface ICtrlService {
        List<MyObject> SomeMethod();
    }
    public ControllerA : Controller {
        ICtrlService service;
        public MyController(ICtrlService service){
            this.service = service
        }
    
        public JsonResult SomeAction() {
            List<MyObject> result = service.SomeMethod();
            return Json(result);
        }
    }
