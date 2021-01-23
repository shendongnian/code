    //open file
    StreamWriter wr = new StreamWriter(@"D:\\Book1.xls");
    try
    {
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
        }
        wr.WriteLine();
        //write rows to excel file
        for (int i = 0; i < (dt.Rows.Count); i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (dt.Rows[i][j] != null)
                {
                    wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                }
                else
                {
                    wr.Write("\t");
                }
            }
            //go to next line
            wr.WriteLine();
        }
        //close file
        wr.Close();
    }
    catch (Exception ex)
    {
        throw ex;
    }
