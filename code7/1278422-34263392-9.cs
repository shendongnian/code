     private const string radioButtonGroupNamePrefix = "radioButtonGroupName";
            private const string radioButtonIDPrefix = "radioButton";
    
            protected void Page_Load(object sender, EventArgs e)
            {
                InitializeRadioButtonList();
            }
    
            private void InitializeRadioButtonList()
            {
              // you can fetch data here and then use.
              // for example returns 5 rows from database then you must change "for" syntax 
                for (int i = 0; i < 4; i++)//rows count
                {
                    var row = new TableRow();
    
                    for (int j = 0; j < 3; j++)
                    {
                        var cell = new TableCell();
    
                        var radioButton = new RadioButton();
                        radioButton.ID = string.Format("{0}_{1}_{2}", radioButtonIDPrefix, i,j);
                        radioButton.Text = radioButton.ID;
                        radioButton.GroupName = string.Format("{0}_{1}", radioButtonGroupNamePrefix, i);//same gruop name for same row
                        cell.Controls.Add(radioButton);
    
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                }
            }
    
    
            protected void submit_Click(object sender, EventArgs e)
            {
                foreach (var item in Request.Form.AllKeys)
                {
                    if (item.Contains(radioButtonGroupNamePrefix))
                    {
                        var radioButton = (FindControl(item) as RadioButton);
                    }
                }
                //TODO : DB operations
            }
