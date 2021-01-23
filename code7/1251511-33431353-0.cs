    private void tbSysDateTo_Validating(object sender, CancelEventArgs e)
    {
        DateTime dateValue;
        if (!String.IsNullOrEmpty(tbSysDateTo.Text))
        {
            if (DateTime.TryParseExact(tbSysDateTo.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
                tbSysDateTo.Text = String.Format("{0:MM/dd/yyyy}", dateValue);
        }
    }
