    int selectedColumnIndex = 0;
    int selectedRowIndex = 0;
    string lastUserInputText = string.Empty;
        public void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "CellClick")
            {
                //INDEX INFO
                selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                //TRIGGERS EVENT FOR SELECTED CELL
                GridView1.Rows[selectedRowIndex].Cells[selectedColumnIndex].Attributes["style"] += "background-color:Red;";
                TextBox scheduleBox = new TextBox();
                scheduleBox.CssClass = "redCell";
                
                //This formats the ID so its unique, and now the TextBox contains the row and colummn indexes:
                scheduleBox.ID = "ActiveCell_" + selectedRowIndex.ToString() + "_" + selectedColumnIndex.ToString();
                scheduleBox.TextChanged += scheduleBox_TextChanged;
                scheduleBox.Width = 35;
                this.GridView1.Rows[selectedRowIndex].Cells[selectedColumnIndex].Controls.Add(scheduleBox);
                scheduleBox.Focus();
                //LABEL INDEX INFO
                lblCell.Text = (selectedColumnIndex - 2).ToString();
                ////LABEL HEADER & ROW TITLES
                lblStartTime.Text = GridView1.Rows[selectedRowIndex].Cells[1].Text;
            }
            GridView1.DataBind();
        }
    //The following event gets the current index of the Row and the column where the user is changing the text
        void scheduleBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSelected = (TextBox)sender;
            string[] selectedValues = txtSelected.ID.Split(new char[] { '_' });
            selectedRowIndex = int.Parse(selectedValues[1]);
            selectedColumnIndex = int.Parse(selectedValues[2]);
            //you could also use it to get the text directly while the user is editing it:
            lastUserInputText = txtSelected.Text;
        }
    //This gets the text for the selected row and column. But if you only have 1 column with a TextBox it would be easier to just use the column index constant instead of doing it dynamically. However, remember you already have this value in the "lastUserInputText" variable. If you use that the following code may not be necessary:
    string GetTextFromSelectedRowTextBox()
    {
        string textBoxValue = string.Empty;
        foreach (Control curControl in this.GridView1.Rows[selectedRowIndex].Cells[selectedColumnIndex].Controls)
        {
            if (curControl is TextBox)
            {
                TextBox txtScheduleBox = (TextBox)curControl;
                textBoxValue = txtScheduleBox.Text;
                break;
            }
        }
        return textBoxValue;
    }
