    private void LookupLogs_Click(object sender, EventArgs e)
        {
            Statustextbox.Clear();
            string query = "<QueryList>" +
                           "  <Query Id=\"0\" Path=\"Security\">" +
                           "    <Select Path=\"Security\">" +
                           "        *[System[band(Keywords,4503599627370496)]] and *[EventData[Data[@Name='TargetUserName'] and (Data='" + Username.Text + "')]]" +
                           "    </Select>" +
                           "  </Query>" +
                           "</QueryList>";
            EventLogSession session = new EventLogSession(DomainController.Text);
            EventLogQuery evntquery = new EventLogQuery("Security", PathType.LogName, query);
            evntquery.Session = session;
            try
            {
                EventLogReader logreader = new EventLogReader(evntquery);
                DisplayEventAndLogInformation(logreader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occured: " + ex.Message);
            }
        }
    private void DisplayEventAndLogInformation(EventLogReader logReader)
        {
            for (EventRecord eventInstance = logReader.ReadEvent();
                null != eventInstance; eventInstance = logReader.ReadEvent())
            {
                Statustextbox.AppendText(Environment.NewLine + Environment.NewLine);
                Statustextbox.AppendText("---------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                Statustextbox.AppendText("Event ID: " + eventInstance.Id + Environment.NewLine);
                Statustextbox.AppendText("Publisher: " + eventInstance.ProviderName + Environment.NewLine);
                try
                {
                    Statustextbox.AppendText("Description: " + eventInstance.FormatDescription() + Environment.NewLine);
                }
                catch (EventLogException ex)
                {
                    Statustextbox.AppendText("An exception was thrown: " + ex.Message + Environment.NewLine);
                }
                EventLogRecord logRecord = (EventLogRecord)eventInstance;
                Statustextbox.AppendText(Environment.NewLine);
                Statustextbox.AppendText("Container Event Log: " + logRecord.ContainerLog + Environment.NewLine);
            }
        }
