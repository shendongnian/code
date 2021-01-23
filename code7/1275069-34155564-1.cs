    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        if (Conditions are met)
        {
            string resultFromApi = SMS.OneToOneBulk(messageHeader, SMS_number_list);
        }
    }
