    private async Task ProcessItemAsync(Item item)
    {
        if (ConditionA(item))
        {
            if (ConditionAB(item));
            {
                await CreateThingViaAPICall(item)
            }
            else
            {
                var result = await GetExistingRecord(item);
                var result2 = await GetOtherExistingRecord(result);
                var result3 = await GetOtherExistingRecord(result2);
                //Do processing
                ...           
                await CreateThingViaAPICall();
            }
        }
        ... and so on
    }
