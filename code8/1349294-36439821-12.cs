    private void Floor_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (Floor.SelectedItem.ToString() != "SELECT FLOOR")
            {
                foreach (var item in roomInfoDataSet1.Table.Where(x => x.Room_Number.Substring(0,1) == Convert.ToString(Floor.SelectedValue)))
                {
                    string[] row = new string[] { item.Room_Number, item.Equipment_Type, item.Availability, Convert.ToString(Floor.SelectedValue) };
                    dataGridView1.Rows.Add(row);
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                }
            }
        }
