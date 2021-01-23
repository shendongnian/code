    public void RemoveNoLongerRequired<T>(List<NewPerson> newPeople,
      List<T> masterPeople) where T : IPerson
    {
      var noLongerNewPeople = masterPeople.Where(a => !newPeople.Any(b =>
        a.PerId == b.PerId && a.AddressId == b.AddressId));
      foreach (var item in noLongerNewPeople)
      {
        if (typeof(T) == typeof(MasterPerson))
        {
          _masterRepository.DeleteMasterPerson((item as MasterPerson).MvpId);
          continue;
        }
        if (typeof(T) == typeof(ExceptionPerson))
        {
          _exceptionRepository.DeleteExceptionPerson((item as ExceptionPerson).EvpId);
          continue;
        }
        throw new NotImplementedException();
      }
    }
