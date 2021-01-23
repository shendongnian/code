    public class MyController : Controller
    {
        private readonly IDependency _dependency;
        public MyController ()
            : this(new ActuallImplementationOfDependency())
        {
        }
        public MyController (IDependency dependency)
        {
            _dependency = dependency;
        }
        // ...
}
