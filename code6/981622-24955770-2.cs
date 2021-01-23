        IUnitOfWork UnitOfWork { get; }
    }
    public class Repository<TEntity> : IRepository<TEntity>
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
    public interface IUnitOfWork { }
    class UnitOfWorkA : IUnitOfWork { }
    class UnitOfWorkB : IUnitOfWork { }
    public class Test
    {
        [Fact]
        public void asdf()
        {
            var kernel = new StandardKernel();
            kernel.Bind(typeof (IRepository<>)).To(typeof (Repository<>));
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkA>()
                .When(request => IsRepositoryFor(request, new[] { typeof(string), typeof(bool) })); // these are strange entity types, i know ;-)
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkB>()
                .When(request => IsRepositoryFor(request, new[] { typeof(int), typeof(double) }));
            // assert
            kernel.Get<IRepository<string>>()
                .UnitOfWork.Should().BeOfType<UnitOfWorkA>();
            
            kernel.Get<IRepository<double>>()
                .UnitOfWork.Should().BeOfType<UnitOfWorkB>();
        }
        private bool IsRepositoryFor(IRequest request, IEnumerable<Type> entities)
        {
            if (request.ParentRequest != null)
            {
                Type injectInto = request.ParentRequest.Service;
                if (injectInto.IsGenericType && injectInto.GetGenericTypeDefinition() == typeof (IRepository<>))
                {
                    Type entityType = injectInto.GetGenericArguments().Single();
                    return entities.Contains(entityType);
                }
            }
            return false;
        }
    }
