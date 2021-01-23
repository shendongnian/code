    public async Task DeleteAmendment(int amendmentHeaderId, int userId)
    {
        Task.Run(() =>
        {
            // Delete the corresponding version records.
            await _amendmentVersionService.DeleteForAmendmentAsync(amendmentHeaderId);
         }).ContinueWith(_ => 
         {
            // Delete the corresponding lifecycle records.
            await _amendmentLifecycleService.DeleteForAmendmentAsync(amendmentHeaderId);
         }).ContinueWith(_ => 
        {
            // Delete the amendment header record itself.
            await _amendmentHeaderService.DeleteAsync(amendmentHeaderId, userId);
        });
    }
