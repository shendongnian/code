    using Ninject;
    using Ninject.Syntax;
    namespace NinjectTest.SO38013150
    {
        public interface IUnitOfWork { }
        internal class UnitOfWork : IUnitOfWork { }
        public interface IUnitOfWorkFactory
        {
            IUnitOfWork Create();
        }
        internal class UnitOfWorkFactory : IUnitOfWorkFactory
        {
            private readonly IResolutionRoot resolutionRoot;
            public UnitOfWorkFactory(IResolutionRoot resolutionRoot)
            {
                this.resolutionRoot = resolutionRoot;
            }
            public IUnitOfWork Create()
            {
                return this.resolutionRoot.Get<IUnitOfWork>();
            }
        }
    }
