    for (int i = 0; i < columns.Count(); i++ )
    {
    	//create label
    	Label newLbl = new Label() {Text=columns[i].ToString()};
    	//add to list
    	labelList.Add(newLbl);
    	//add to form
    	updateDialog.Controls.Add(newLbl);
    	//show on msg box
    	MessageBox.Show(newLbl.Text.ToString());
    }
