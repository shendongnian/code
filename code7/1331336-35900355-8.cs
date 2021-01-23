      int clickcount = 0;
        List<int> matchList = new List<int>();
    
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            if (clickcount == 0)
            {
                //get the search term from the textbox
                String searchTerm = textBox.Text;
                //if the column index is 1 the we search by code and 2 if we search by name
                int columnIndex = 0;
                if (codeRadioBtn.Checked)
                    columnIndex = 1;
                else
                    columnIndex = 2;
    
                gridView.ClearSelection();
    
                int firstIndex = 0;
                bool found = false;
    
                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    //change background color to DarkOrange for the rows that contain the searched value
                    if (gridView.Rows[i].Cells[columnIndex].Value.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        //gridView.Rows[i].Selected = true;
    
                   
                        this.gridView.CurrentCell = gridView.Rows[0].Cells[0];
                        gridView.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                        matchList.Add(i);
                        found = true;
    
                        if (firstIndex < 1)
                        {
                            firstIndex = i;
                        }
                    }
                }
                //display message if no item was found 
                if (!found)
                {
                    MessageBox.Show("The search term was not found", "Warning");
                }
               //add one to the count to stop the search happing again.
                clickcount = 1;
            }
            else
            {
                //if clickcount = 1+ or your've reached the end of your match list count
                  if (clickcount != 0 && clickcount != matchList.Count - 1)
                {
    
                  
                    //gridView.Rows[clickcount].DefaultCellStyle.BackColor = Color.Red;
                    this.gridView.CurrentCell = gridView.Rows[matchList[clickcount]].Cells[0];
               
                    clickcount++;
                }
                else
                  {
                      MessageBox.Show("No More Found");
                    clickcount = 0;
                    matchList.Clear();
                }
    
            }
        }
