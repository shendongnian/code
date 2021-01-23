    private int LoadData()
    {
        try
        {
            return testTableAdapter.Fill(testDataSet.tbl); 
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.ToString());
        }
        
        return -1;
    }
