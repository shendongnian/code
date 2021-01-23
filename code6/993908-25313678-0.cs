    [CustomActionFilter]
    public class MyController : ApiController {
        public ActionResult MyAction() {
            var myAttribute = ControllerContext
                              .ControllerDescriptor
                              .GetCustomAttributes<CustomActionFilter>()
                              .Single();
            var success = myAttribute.success;
        }
    }
