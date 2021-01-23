    private int loadData()
    {
        try
        {
             testTableAdapter.Fill(testDataSet.tbl); 
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.ToString());
        }
    }
