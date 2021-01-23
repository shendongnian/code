    [System.Web.Http.Route("~/api/sorted")]
    // missing async in signature (not good if you are calling it with await in your controller)
    public async Task<List<Restaurant>> GetSorted(string outcode)
    {
        if (string.IsNullOrEmpty(outcode)) throw new ArgumentNullException(nameof(outcode));
        // added await in call
        return await _repository.GetSortedRestaurantsByOutcode(outcode);
    }
