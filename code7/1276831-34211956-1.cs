    private class IdAndList
    {
      public int Id { get; set; }
      public List<string> PetList { get; set; }
    }
    private class ReportIdAndPetListComparer : IEqualityComparer<IdAndList>
    {
      public bool Equals(IdAndList x, IdAndList y)
      {
        if (ReferenceEquals(x, y)) return true;
        if (x == null || y == null) return false;
        if (x.Id != y.Id) return false;
        if (x.PetList == null) return y.PetList == null;
        if (y.PetList == null) return false;
        int count = x.PetList.Count;
        if (y.PetList.Count != count) return false;
        for (int i = 0; i != count; ++i)
          if (x.PetList[i] != y.PetList[i]) return false;
        return true;
      }
      
      public int GetHashCode(IdAndList obj)
      {
        int hash = obj.Id;
        if (obj.PetList != null)
          foreach (string pet in obj.PetList)
            hash = hash * 31 + pet.GetHashCode();
        return hash;
      }
    }
