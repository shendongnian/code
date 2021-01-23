    public class ProgramStarter
    {
        private readonly IService _service;
        public ProgramStarter(IService service)
        {
            // Unity has created this instance and resolved all dependencies.
            _service= service;
        }
        public void Run()
        {
            // Do what you want to do.
        }
    }
