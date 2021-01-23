    private void Adapter_RowUpdating(object sender, System.Data.SqlClient.SqlRowUpdatingEventArgs e)
    {
        if (e.StatementType == StatementType.Delete)
        {
            pROCFixedIncomeTradesSelectTableAdapter.Adapter.DeleteCommand.Parameters["@Deleted"].Value = DateTime.Now;
            pROCFixedIncomeTradesSelectTableAdapter.Adapter.DeleteCommand.Parameters["@DeletedBy"].Value = Environment.UserName;
        }
    }
