    DataTable ret = functionThatGetsaDataTableUsingSQL(); //Original DataTable
    DataTable dt = new DataTable(); //Final DataTable
    foreach (DataRow dr in ret.Rows)
    {
        DataRow row = dt.Rows.Add();
        for (int j = 0; j < dr.ItemArray.Length; j++)
        {
            if (j == 14) row[j] = string.Format("{0:C2}", dr.ItemArray[j]);
            else row[j] = dr.ItemArray[j];
        }
    }
