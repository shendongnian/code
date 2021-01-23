		public class ShoppingListService : ServiceBase, IShoppingListService
		{
			private readonly IRepository<ShoppingList, int> _shoppingListRepository;
			private readonly IRepository<ShoppingListEntry, int> _shoppingListEntryRepository;
			public ShoppingListService(IRepository<ShoppingList, int> shoppingListRepository,
				IRepository<ShoppingListEntry, int> shoppingListEntryRepository)
			{
				_shoppingListRepository = shoppingListRepository;
				_shoppingListEntryRepository = shoppingListEntryRepository;
			}
			public IOutputDataModel<ListModel<ShoppingListDto>> GetUserShoppingLists(GetUserShoppingListsInput model)
			{
				var shoppingLists =
					_shoppingListRepository.Get(q => q.Filter(sl => sl.OwnerId == model.InitiatorId).Include(sl => sl.Entries));
				return SuccessOutput(new ListModel<ShoppingListDto>(Mapper.Map<IEnumerable<ShoppingList>, ShoppingListDto[]>(shoppingLists)));
			}
			public IOutputDataModel<GetShoppingListOutputData> GetShoppingList(GetShoppingListInput model)
			{
				var shoppingList =
					_shoppingListRepository
						.Get(q => q.Filter(sl => sl.Id == model.ShoppingListId).Include(sl => sl.Entries).Take(1))
						.SingleOrDefault();
				if (shoppingList == null)
					return Output<GetShoppingListOutputData>(OperationResult.NotFound);
				if (shoppingList.OwnerId != model.InitiatorId)
					return Output<GetShoppingListOutputData>(OperationResult.AccessDenied);
				return
					SuccessOutput(new GetShoppingListOutputData(Mapper.Map<ShoppingListDto>(shoppingList),
						Mapper.Map<IEnumerable<ShoppingListEntry>, List<ShoppingListEntryDto>>(shoppingList.Entries)));
			}
			public IOutputModel DeleteShoppingList(DeleteShoppingListInput model)
			{
				var shoppingList = _shoppingListRepository.Get(model.ShoppingListId);
				if (shoppingList == null)
					return Output(OperationResult.NotFound);
				if (shoppingList.OwnerId != model.InitiatorId)
					return Output(OperationResult.AccessDenied);
				_shoppingListRepository.Delete(shoppingList);
				
				return SuccessOutput();
			}
			public IOutputModel DeleteShoppingListEntry(DeleteShoppingListEntryInput model)
			{
				var entry =
					_shoppingListEntryRepository.Get(
						q => q.Filter(e => e.Id == model.ShoppingListEntryId).Include(e => e.ShoppingList).Take(1))
						.SingleOrDefault();
				if (entry == null)
					return Output(OperationResult.NotFound);
				if (entry.ShoppingList.OwnerId != model.InitiatorId)
					return Output(OperationResult.AccessDenied);
				if (entry.ShoppingListId != model.ShoppingListId)
					return Output(OperationResult.BadRequest);
				_shoppingListEntryRepository.Delete(entry);
				return SuccessOutput();
			}
			public IOutputModel ClearShoppingListEntries(ClearShoppingListEntriesInput model)
			{
				var shoppingList =
					_shoppingListRepository.Get(
						q => q.Filter(sl => sl.Id == model.ShoppingListId).Include(sl => sl.Entries).Take(1))
						.SingleOrDefault();
				if (shoppingList == null)
					return Output(OperationResult.NotFound);
				if (shoppingList.OwnerId != model.InitiatorId)
					return Output(OperationResult.AccessDenied);
				if (shoppingList.Entries != null)
					_shoppingListEntryRepository.Delete(shoppingList.Entries.ToList());
				return SuccessOutput();
			}
			private IOutputDataModel<int> CreateShoppingList(SaveShoppingListInput model)
			{
				var shoppingList = new ShoppingList
				{
					OwnerId = model.InitiatorId,
					Title = model.ShoppingListTitle,
					Entries = model.Entries.Select(Mapper.Map<ShoppingListEntry>).ForEach(sle => sle.Id = 0).ToList()
				};
				shoppingList = _shoppingListRepository.Save(shoppingList);
				return Output(OperationResult.Created, shoppingList.Id);
			}
		}
