    public class IncomingAttachesCollectionViewModel : CollectionViewModel<EfAttach, Guid, IDomainModelContextUnitOfWork> {
        internal static IncomingAttachesCollectionViewModel Create(IUnitOfWorkFactory<IDomainModelContextUnitOfWork> unitOfWorkFactory = null,
            Func<IRepositoryQuery<EfAttach>, IQueryable<EfAttach>> projection = null,
            Action<EfAttach> propertyInitializer = null,
            Func<bool> canCreateNewEntity = null) {
            return ViewModelSource.Create(() => new IncomingAttachesCollectionViewModel(unitOfWorkFactory, projection, propertyInitializer, canCreateNewEntity));
        }
        protected IncomingAttachesCollectionViewModel(IUnitOfWorkFactory<IDomainModelContextUnitOfWork> unitOfWorkFactory = null,
            Func<IRepositoryQuery<EfAttach>, IQueryable<EfAttach>> projection = null,
            Action<EfAttach> propertyInitializer = null,
            Func<bool> canCreateNewEntity = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Attaches, projection, propertyInitializer, canCreateNewEntity) {
        }
        public override void New() {
            base.New();
            /*  do something here */
        }
    }
