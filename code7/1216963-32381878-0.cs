    [Route("Api/Deliveries/{id}/{StringVal}/{AlphaVal}")]
    public IEnumerable<Deliveries> GetByAdvanced(int id, string StringVal, string AlphaVal)
    {
      var deliveries = ...
      return deliveries;
    }
