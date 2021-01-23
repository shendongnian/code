    private void searchart()
    {
      int itemrow = -1;
      String searchValue = cueTextBox1.Text.ToUpper();
      if (searchValue != null && searchValue != "")
        {
        foreach (DataGridViewRow row in dataGridView1.Rows)
          {
          //search for identical art
          if (row.Cells[0].Value.ToString().Equals(searchValue))
            {
              itemrow = row.Index;
              break;//stop searching if it's found
            }
          //search for first art that contains search value
          else if (row.Cells[0].Value.ToString().Contains(searchValue) && itemrow == -1)
          {
            itemrow = row.Index;
          }
        }
        //if nothing found set color red
        if (itemrow == -1)
        {
          cueTextBox1.BackColor = Color.Red;
        }
        //if found set color white, select the row and go to the row
        else
        {
          cueTextBox1.BackColor = Color.White;
          dataGridView1.Rows[itemrow].Selected = true;
          dataGridView1.FirstDisplayedScrollingRowIndex = itemrow;
        }
      }
    }
