    public class MyControllerBase<T> : Controller {
        // base class stuff here based on type T's interface
    }
    public class MyController : MyControllerBase<MyController> {
        // regular class here, sending MyController to the base
    }
