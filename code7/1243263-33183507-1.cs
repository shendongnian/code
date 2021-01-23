    if (e.Key == System.Windows.Input.Key.Delete) {
            if (dataGrid.SelectedItem == null)
                return;
            Connect();
            const int blockSize = 100;
            var inOperands = dataGrid.SelectedItems
                                     .Select((e,i) => new { 
                                        row = ((DataRowView) e)["ID"], i        
                                      })
                                     .GroupBy(e => e.i / blockSize)
                                     .Select(g => string.Format("({0})", 
                                                  string.Join(",", g.Select(o => o.row))));
            foreach(var inOperand in inOperands) {
               using (var mCmd = new SQLiteCommand("DELETE FROM clients WHERE ID IN " + inOperand, mConn)) {
                  mCmd.ExecuteNonQuery();
               }
            }
            mAdapter.Update(mTable);
            mConn.Close();
    }
