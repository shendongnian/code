    private IEnumerable<SortModel> GetSortModel(string sortModel)
    {
         if (sortModel == null)
         {
             return Enumerable.Empty<SortModel>();
         }
         string array = $"[{sortModel}]"; 
         var deserialized = JsonConvert.DeserializeObject<List<SortModel>>(array);
         return deserialized;
     }
