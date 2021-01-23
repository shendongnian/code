    public void RemoveNoLongerRequired<T>(List<NewPerson> newPeople,
      List<T> masterPeople) where T : IPerson
    {
      var noLongerNewPeople = masterPeople.Where(a => !newPeople.Any(b =>
        a.PerId == b.PerId && a.AddressId == b.AddressId));
      foreach (var item in noLongerNewPeople)
      {
        if (typeof(T) == typeof(MasterPerson))
        {
          _masterRepository.DeleteMasterPerson(item.UniqueEntityId);
          continue;
        }
        if (typeof(T) == typeof(ExceptionPerson))
        {
          _exceptionRepository.DeleteExceptionPerson(item.UniqueEntityId);
          continue;
        }
        throw new NotImplementedException();
      }
    }
