    if (e.Key == System.Windows.Input.Key.Delete) {
            if (dataGrid.SelectedItem == null)
                return;
            Connect();
            foreach(var item in dataGrid.SelectedItems.Cast<DataRowView>()) {
               using (var mCmd = new SQLiteCommand("DELETE FROM clients WHERE ID=" + item["ID"], mConn)) {
                  mCmd.ExecuteNonQuery();
               }
            }
            mAdapter.Update(mTable);
            mConn.Close();
    }
