    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    med_id = dataGridView1.Rows[e.RowIndex].Cells["Med_id"].Value.ToString();
    
    if (med_id == "")
    {
    med_id1 = 0;
    }
    else
    {
    med_id1 = Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells["Med_id"].Value.ToString());
    
    }
    if (med_id1 == 0)
    {
    try
    {
    string Medicine_Name = dataGridView1.Rows[e.RowIndex].Cells["Medicine_Name"].Value.ToString();
    string Dealer_name = dataGridView1.Rows[e.RowIndex].Cells["Dealer_name"].Value.ToString();
    int Availability = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Availability"].Value.ToString());
    string cmd1 = "insert into Medicine_Available_Detail(Medicine_Name,Dealer_name,Availability) values(@Medicine_Name,@Dealer_name,@Availability)";
    OleDbCommand cmd = new OleDbCommand(cmd1, con);
    
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@Medicine_Name", Medicine_Name);
    cmd.Parameters.AddWithValue("@Dealer_name", Dealer_name);
    cmd.Parameters.AddWithValue("@Availability", Availability);
    con.Open();
    int n = cmd.ExecuteNonQuery();
    con.Close();
    if (n > 0)
    {
    
    MessageBox.Show("Data Inserted Successfully", "Data Inserted ", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
    
    }
    Load_data();
    dataGridView1.Refresh();
    }
    catch (Exception ex)
    {
    
    }
    
    
    }
    else
    {
    string Medicine_Name = dataGridView1.Rows[e.RowIndex].Cells["Medicine_Name"].Value.ToString();
    string Dealer_name = dataGridView1.Rows[e.RowIndex].Cells["Dealer_name"].Value.ToString();
    int Availability = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Availability"].Value.ToString());
    cmd = new OleDbCommand();
    
    cmd.CommandType = CommandType.Text;
    cmd = con.CreateCommand();
    cmd.CommandText = "update Medicine_Available_Detail set Medicine_Name='" + dataGridView1.Rows[e.RowIndex].Cells["Medicine_Name"].Value.ToString() + "',Dealer_name='" + dataGridView1.Rows[e.RowIndex].Cells["Dealer_name"].Value.ToString() + "',Availability='" + Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Availability"].Value.ToString())+ "'where Med_id=" + med_id1 + "";
    con.Open();
    int n = cmd.ExecuteNonQuery();
    con.Close();
    if (n > 0)
    {
    
    MessageBox.Show("Data Updated Successfully", "Data Inserted ", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
    
    }
    Load_data();
    dataGridView1.Refresh();
    
    }
    }
 
