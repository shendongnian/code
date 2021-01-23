    public class Test
    {
        [Fact]
        public void asdf()
        {
            var kernel = new StandardKernel();
            kernel.Bind(typeof (IRepository<>)).To(typeof (Repository<>));
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkA>()
                .When(request => IsRepositoryFor(request, "TRZIC")); // these are strange entity types, i know ;-)
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkB>()
                .When(request => IsRepositoryFor(request, "INIC"));
            // assert
            kernel.Get<IRepository<TRZIC_Foo>>()
                .UnitOfWork.Should().BeOfType<UnitOfWorkA>();
            
            kernel.Get<IRepository<INIC_Bar>>()
                .UnitOfWork.Should().BeOfType<UnitOfWorkB>();
        }
        private bool IsRepositoryFor(IRequest request, string entityNameStartsWith)
        {
            if (request.ParentRequest != null)
            {
                Type injectInto = request.ParentRequest.Service;
                if (injectInto.IsGenericType && injectInto.GetGenericTypeDefinition() == typeof (IRepository<>))
                {
                    Type entityType = injectInto.GetGenericArguments().Single();
                    return entityType.Name.StartsWith(entityNameStartsWith, StringComparison.OrdinalIgnoreCase);
                }
            }
            return false;
        }
    }
