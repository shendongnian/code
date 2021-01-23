    public FormNewAppointment()
    {
        InitializeComponent();
        cmbBoxLength.Items.AddRange(new object[] { 30, 60, 90 });
        DateTime EndTime = time.AddHours(22);    
        for (time = time.AddHours(8); time < EndTime; time = time.AddMinutes(30))
        {
            cmbBoxStart.Items.Add(time.ToShortTimeString());
        }
    }
