    public IncomingAttachesCollectionViewModel EfIncomingAttachesDetails {
        get { return GetIncomingAttachesDetails(x => x.EfIncomingAttachesDetails); }
    }
    protected IncomingAttachesCollectionViewModel GetIncomingAttachesDetails(
        Expression<Func<EfIncomingViewModel , IncomingAttachesCollectionViewModel>> propertyExpression) {
        return GetCollectionViewModelCore<IncomingAttachesCollectionViewModel, EfAttach, EfAttach, Guid>(
            propertyExpression, () => IncomingAttachesCollectionViewModel.Create(UnitOfWorkFactory,
                    AppendForeignKeyPredicate<EfAttach, EfAttach, Guid>(x => x.DocumentID, null),
                    CreateForeignKeyPropertyInitializer<EfAttach, Guid>((x, key) => x.DocumentID = key, () => PrimaryKey),
                    () => CanCreateNewEntity()));
    }
