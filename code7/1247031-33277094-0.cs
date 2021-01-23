    void Main()
    {
      InsertOrUpdateRecord(new PoiModel()); // Prints p => p.PoiId == record.PoiId
      InsertOrUpdateRecord(new AnotherModel()); // Prints a => a.AnotherId == record.AnotherId
      InsertOrUpdateRecord("Hi!"); // throws NotSupportedException
    }
    
    class PoiModel { public int PoiId; }
    class AnotherModel { public int AnotherId; }
    
    public void InsertOrUpdateRecord<T>(T record)
    {
      GetIdQuery(record).Dump(); // Print out the expression
    }
    
    private Expression<Func<T, bool>> GetIdQuery<T>(T record)
    {
      return GetIdQueryInternal((dynamic)record);
    }
    
    private Expression<Func<PoiModel, bool>> GetIdQueryInternal(PoiModel record)
    {
      return p => p.PoiId == record.PoiId;
    }
    private Expression<Func<AnotherModel, bool>> GetIdQueryInternal(AnotherModel record)
    {
      return a => a.AnotherId == record.AnotherId;
    }
    
    private Expression<Func<T, bool>> GetIdQueryInternal<T>(T record)
    {
      // Return whatever fallback, or throw an exception, whatever suits you
      throw new NotSupportedException();
    }
