    [TestMethod]
    public void BaseRepository_Update() {
      AddAllPatients();
      Assert.AreEqual(_patients.Count, _patientsRepository.GetAll().Count());
    }
    #region Helper methods
    private List<Patient> GetPatients() {
      return Enumerable.Range(1, 10).Select(CreatePatient).ToList();
    }
    private static Patient CreatePatient(int id) {
      return new Patient {
        ID = id,
        FirstName = "FirstName_" + id,
        Surname = "Surname_" + id,
        Address1 = "Address1_" + id,
        City = "City_" + id,
        Postcode = "PC_" + id,
        Telephone = "Telephone_" + id
      };
    }
    private void AddAllPatients() {
      _patients.ForEach(p => _patientsRepository.Update(p));
    }
    #endregion
