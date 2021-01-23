    public class BaseController {
        protected IMyExampleServer MyExampleService { get; set; };
        public BaseController(IContainer container) {
            container.ObjectFactory.BuildUp(this);
        }
        ....
    }
