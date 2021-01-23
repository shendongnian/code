    private void InitColourComboBoxColumn()
    {
        try
        {
            cboColumn = new DataGridViewComboBoxColumn();
            cboColumn.Name = "Colour";
            cboColumn.ValueMember = "Name";
            List<ushort> listColours = new List<ushort>();
            listColours.Add(1);
            listColours.Add(2);
            listColours.Add(3);
            listColours.Add(4);
            listColours.Add(5);
            listColours.Add(6);
            listColours.Add(7);
            listColours.Add(8);
            listColours.Add(9);
            listColours.Add(250);
            listColours.Add(251);
            listColours.Add(252);
            listColours.Add(253);
            listColours.Add(254);
            listColours.Add(255);
            foreach (ushort iColourIndex in listColours)
                cboColumn.Items.Add(ComboboxColourItem.Create(iColourIndex));
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
