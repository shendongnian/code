    private SummaryPatient _patient;
    public SummaryPatient Patient
    {
        get
        {
            if (_patient == null)
                _patient  = new SummaryPatient(PatientBusinessService.FindPatient(this.PatientId));
            return _patient;
        }
    }
