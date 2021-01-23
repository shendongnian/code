    private void QueueBindZoneColumn()
    {
      // The available ZoneId list may have been edited, so get a fresh copy
      DataGridViewComboBoxColumn c = (DataGridViewComboBoxColumn)dgv1.Columns["ZoneId"];
      if (c != null) {
        c.ValueType = typeof(string);
        List<Data.Zone> ZoneList;
        if (Data.LoadZoneId.Load(txtConnectionString.Text, out ZoneList)) {
          c.DataSource = ZoneList;
          c.DisplayMember = "ZoneDescription";    //List class member name to display as descriptions
          c.ValueMember = Data.FieldNameHandling.Id;  //List class member name to use as the stored value
        }
      }
    }
