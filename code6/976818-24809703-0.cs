    string GetTextFromSelectedRowTextBox()
    {
        string textBoxValue = string.Empty;
        int selectedRowIndex = this.GridView1.SelectedIndex;
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
