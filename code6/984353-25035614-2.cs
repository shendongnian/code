    private async void button1_Click(object sender, EventArgs e)
    {
     dtFrom.Format = DateTimePickerFormat.Short;
     dtTo.Format = DateTimePickerFormat.Short;
     DataTable dt = new DataTable();
     dt = await GetExtMsg(dtFrom.Text, dtTo.Text);
    }
