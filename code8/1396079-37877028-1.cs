    private async Task TellWebServiceToRemoveAsync()
    {
        await webService.RemoveAsync(); // or whatever it's called
        // do what you need to do when webservice has finished
        // this will happen on the UI thread again
    }
    public override bool OnContextItemSelected(IMenuItem item)
    {
        if (item.ItemId == Resource.Id.delete)
        {
            TellWebServiceToRemoveAsync();
            return true;                   
        }
    }
    
