    public async Task SomeConsumerOfYourObject()
    {
        var wcfObj = new YourWcfObject();
        await wcfObj.LoadDataAsync(this.Uri);
        
        // Then you're good...
    } 
