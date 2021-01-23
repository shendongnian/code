    private DataTable FilterDMRMarcIDs()
    {
        var tmpValue = dtDMRMarc.AsEnumerable();
        
        if (chekbCountry.Checked)
        {
             tmpValue = tmpValue.Where(contact => contact.Field<string>("Country") == (string)cbCountry.SelectedItem);
        }
        if (chekbState.Checked)
        {
            tmpValue = tmpValue.Where(contact => contact.Field<string>("State") == (string)cbState.SelectedItem);
        }
        return tmpValue.CopyToDataTable<DataRow>();
    }    // FilterDMRMarcIDs() ...
