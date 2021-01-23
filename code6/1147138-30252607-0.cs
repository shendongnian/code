    public async Task LoadAsync()
    {
         IsBusy =true;
         var firstDropDownItemsTask = repository.LoadStates();
         var secondDropDownItemsTask = repository.LoadInstitutes();
         await Task.WhenAll(DropDownItems1Task, DropDownItems2Task);
         DropDownItems1 =  firstDropDownItemsTask.Result;
         DropDownItems2 = secondDropDownItemsTask.Result;
         IsBusy = false;
    }
