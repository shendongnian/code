    public class BaseController {
        protected IMyExampleServer MyExampleService { get; set; };
        public BaseController() {
            ObjectFactory.BuildUp(this);
        }
        ....
    }
