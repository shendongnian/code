        [RoutePrefix("api/ShoppingList/{shoppingListId:int}/ShoppingListEntry")]
		public class ShoppingListEntryController : RikropApiControllerBase
		{
			private readonly IShoppingListService _shoppingListService;
			public ShoppingListEntryController(IShoppingListService shoppingListService)
			{
				_shoppingListService = shoppingListService;
			}
			[Route("")]
			[HttpPost]
			public HttpResponseMessage AddNewEntry(int shoppingListId, SaveShoppingListEntryInput model)
			{
				model.ShoppingListId = shoppingListId;
				var result = _shoppingListService.SaveShoppingListEntry(model);
				return Response(result);
			}
			[Route("")]
			[HttpDelete]
			public HttpResponseMessage ClearShoppingList(int shoppingListId)
			{
				var model = new ClearShoppingListEntriesInput {ShoppingListId = shoppingListId, InitiatorId = this.GetCurrentUserId()};
				var result = _shoppingListService.ClearShoppingListEntries(model);
				return Response(result);
			}
			[Route("{shoppingListEntryId:int}")]
			public HttpResponseMessage Put(int shoppingListId, int shoppingListEntryId, SaveShoppingListEntryInput model)
			{
				model.ShoppingListId = shoppingListId;
				model.ShoppingListEntryId = shoppingListEntryId;
				var result = _shoppingListService.SaveShoppingListEntry(model);
				return Response(result);
			}
			
			[Route("{shoppingListEntry:int}")]
			public HttpResponseMessage Delete(int shoppingListId, int shoppingListEntry)
			{
				var model = new DeleteShoppingListEntryInput 
                {
                    ShoppingListId = shoppingListId, 
                    ShoppingListEntryId = shoppingListEntry,
                    InitiatorId = this.GetCurrentUserId()
                };
				var result = _shoppingListService.DeleteShoppingListEntry(model);
				return Response(result);
			}
		}
