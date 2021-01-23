    async public void PopulateItemList() //!!async keyword
	{
	   foreach(var item in collection)
	   {
		   bool isSuccess = await GetSubItem(item.Id); //!!await
		   if(!isSuccess)
		   {
			   ShowError();
			   break;
		   }
	   }
	}
	public Task<bool> GetSubItem(string parentId)
	{
		var tcs = new TaskCompletionSource<bool>(); //!!
		_service.Communication<ViewModel, Request, Response>((ViewModel vm, ref Request) => 
	   {
		   request.ApiName = Const.FXXXName;
		   request.Id = parentId;
	   }, (viewModel, response, error) =>
	   {
		   DoSomething();
		   ...
		   tcs.SetResult(response.IsOk); //!!
	   }
	   tcs.Task
	}
