    public class ControllerTestable : Controller
    {
        public bool IsCalled = false;
        public override ViewResult SomeAction()
        {
            IsCalled = true;
            return null;
        }
    }
