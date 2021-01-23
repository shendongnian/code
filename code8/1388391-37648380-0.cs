    private async Task<ObservableCollection<ViewDx>> MakePatientListAsync()
    {
      var result = await MedicalClient.GetActiveDxAsync(Encounter.PatientRecid, (DateTime)Encounter.Tencounter);
      dxlist = result.Select(r =>
          new ViewDx
          {
            Cdesc = r.Cdesc,
            Code = r.Code,
            Chronic = r.Chronic
          })
          .ToList();
      return new ObservableCollection<ViewDx>(dxlist);
    }
    public  ListTypes DisplayListType
    {
      get { return displayListType; }
      set
      {
        displayListType = value;
        OnPropertyChanged("DisplayListType");
        switch (value)
        {
          case ListTypes.ActiveDiagnosis:
            DxList = NotifyTask.Create(() => MakePatientListAsync());
            break;
          .......
        }
      }
    }
