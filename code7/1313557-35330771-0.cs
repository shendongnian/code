    try
    {
        clsStockManagement.updateStock(
            int.Parse(TransactionID.Text),
            int.Parse(projectID.Text),
            int.Parse(cbItem.SelectedValue.ToString()),
            int.Parse(tbQty.Text),
            DateTimee.Value);
        MessageBox.Show("Process Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Process UnSuccessful, error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
