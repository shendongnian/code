    int yAxis = 10;
    for (int i = 0; i < columns.Count(); i++ )
    {
    	//create label
    	Label newLbl = new Label() {Text=columns[i].ToString()};
    	newLbl.Location = new Point(10, yAxis * i);	//will create a column of all labels, you can use your oown logic too
    	
    	//add to list
    	labelList.Add(newLbl);
    	
    	//add to form
    	updateDialog.Controls.Add(newLbl);
    	
    	//show on msg box
    	MessageBox.Show(newLbl.Text.ToString());
    }
