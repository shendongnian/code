	public class SingletonDataService : IDataService
	{
		private Func<Owned<IEFUnitOfWork>> _uowFactory;
		public SingletonDataService(Func<Owned<IEFUnitOfWork>> uowFactory)
		{
			_uowFactory = uowFactory
		}
		public List<Folder> GetAllFolders ()
		{
			using (var uow = _uowFactory())
			{
				return uow.Value.FoldersRepository.GetAll();
			}
		}
	}
