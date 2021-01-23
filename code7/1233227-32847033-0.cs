    private void btnSaveAddAsset_Click(object sender, EventArgs e)
    {
        if (txtAddFloor.Text == "" || txtAddRoom.Text == "" || string.IsNullOrWhiteSpace(txtAddFloor.Text) == true || string.IsNullOrWhiteSpace(txtAddRoom.Text) == true)
        {
            MessageBox.Show("Please enter valid information", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }
        else
        {
            ths.lstViewListOfRooms.Items.Add(txtAddFloor.Text).SubItems.Add(txtAddRoom.Text);
            
			String date = "dd/MM/yyyy - HH:mm:ss";
			ths.lstViewListOfRooms.Items[lstViewListOfRooms.Items.Count - 1].SubItems.Add(txtAddDescriptionDetail.Text);
			ths.lstViewListOfRooms.Items[lstViewListOfRooms.Items.Count - 1].SubItems.Add(DateTime.Now.ToString(date));
			con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source =AssetManagement.accdb");
			Ds = new DataSet();
			string query = "INSERT INTO tbl_Assets(asset_floor, asset_room, asset_description, asset_createdOn)" + " VALUES (" + txtAddFloor.Text + "," + txtAddRoom.Text + ", '" + txtAddDescriptionDetail.Text + "' , '" + DateTime.Now.ToString(date) + "'" + ") ";
			con.Open();
			Da = new OleDbDataAdapter(query, con);
			Da.Fill(Ds, "tbl_Assets");
			con.Close();
			this.Close();
		
        }
    }
