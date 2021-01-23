    private void radBrowseEditor1_ValueChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(radBrowseEditor1.Value.ToString()))
        {
            using (StreamReader reader = new StreamReader(radBrowseEditor1.Value.ToString(), System.Text.Encoding.Default))
            {
                HRM.Active.Raw = reader.ReadToEnd();
            }
        }
    }
