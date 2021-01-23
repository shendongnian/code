	public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
    {
        switch (item.ItemId)
        {
            case Resource.Id.action_import:
				try
				{
					_refreshWrapper.IsBusy = true;
					var vm = ((ImportReferenceViewModel)ViewModel);
					await Task.Run(() => vm.ImportCommand.Execute(vm.SelectedTableReferences));				
				}
				finally 
				{
					_refreshWrapper.IsBusy = false;
				}
                break;
            default:
                break;
        }
        return true;
    }
