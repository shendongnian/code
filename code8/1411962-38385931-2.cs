    public IEnumerable<Sample> GetFiltered(
      IEnumerable<Sample> samples, string filtercolumn, object filtervalue
    { 
       return samples.Where(
          x => x.GetType().GetProperty(filtercolumn).GetValue(x, null).Equals(filtervalue)
       );
    }
    IEnumberable<Sample> sampleList;
    var byId = GetFiltered(sampleList, "Id", 100);
    var byDescription = GetFiltered(sampleList, "Description", "Some Value");
