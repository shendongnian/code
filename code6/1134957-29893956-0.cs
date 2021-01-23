    ComboBox_ColumnSchedule[i] = new ComboBox();
    ComboBox_ColumnSchedule[i].Id = "Cbx_" + id;
    ComboBox_ColumnSchedule[i].SelectedIndexChanged += ComboBox_SelectedIndexChanged;
    ...
    private void ComboBox_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{
		ComboBox comboBox = (ComboBox) sender;
        //replace with your criteria
        ComboBox_BeamSchedule.Visible = comboBox.Id == "Cbx_2";
        ...
    }
