     protected void appBillButton_DirectClick(object sender, DirectEventArgs e)
        {
            RowSelectionModel rsm = grid1.SelectionModel.Primary as RowSelectionModel;
            if (rsm.SelectedRows.Count > 0)
            {
                foreach (SelectedRow sr in rsm.SelectedRows)
                {
                    //DoSomeFunction();
                }
                X.Msg.Info("Success", "Function completed successfuly.");
            }
            else
            {
                X.Msg.Alert("Error", "Please select row.").Show();
            }
    }
