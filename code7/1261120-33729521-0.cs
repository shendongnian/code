    private void sendSmsAsync()
    {
        DataTable dtSms = ViewState["dtTemp"] as DataTable;
        if (dtSms.Rows.Count > 0)
        {
            for (int i = 0; i < dtSms.Rows.Count; i++)
            {
               // lines of code to send sms from your SendSMS1()
            }
        }
    }
