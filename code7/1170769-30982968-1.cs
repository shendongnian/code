    DateTime dateTime;
    if (DateTime.TryParseExact(txtData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
    {
        MessageBox.Show("date has been added");
        string s = txtTitolo.Text + ", " + txtData.Text + ", " + txtDim.Text + ", " + txtFormato.Text + ", " + txtRisoluzione.Text;
        listVideo.Items.Add(s);
    }
    else
    {
        MessageBox.Show("invalid date");
    }
