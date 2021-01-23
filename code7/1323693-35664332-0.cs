    public SettingsForm(MainForm mainForm)
    {
        TargetMainForm = mainForm;
        // other constructor code
    }
    private MainForm TargetMainForm { get; set; }
    private void DoSettingsThings()
    {
        // do settings things here
        TargetMainForm.readFiles();
    }
