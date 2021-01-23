    public abstract class A : IVirtualMachineExporter
    {
        private readonly ExportJobRequest _request;
        public A(ExportJobRequest request)
        {
            _request = request;
        }
        public override void Prepare()
        {
            //Now Prepare() has access to the Request because
            //it's contained within A, the class that actually needs it.
        }
    }
