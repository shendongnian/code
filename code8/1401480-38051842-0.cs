    public string[] wantedServices = { "MSSQL$SQL", "SQLBrowser" };
    public TextBox[] txtserviceStatus;
    //Gets Service Status On Load
    public void StartServiceStatus()
    {
        txtserviceStatus = ServiceController.GetServices()
                      .Where(svc => wantedServices.Contains(svc.ServiceName))
                      .Select(sc => sc.Status.ToString())
                      .Select(CreateTextBox)
                      .ToArray();
        txtserviceStatus.ForEach(this.Controls.Add);
    }
    private TextBox CreateTextBox(string text, int i) {
        TextBox textBox = new TextBox();
        textBox.text = text;
        textBox.Left = 0;
        textBox.Top = (i + 1) * 20;
        return textBox;
    }
