    public class NinjectFileLessServiceHostFactory : NinjectServiceHostFactory
    {
        public NinjectFileLessServiceHostFactory()
        {
            SetKernel(NinjectWebCommon.Bootstrapper.Kernel);
        }
    }
