    private void btnEvaluate_Click(object sender, EventArgs e)
    {
        dtgBangketqua.Columns.Add("Evaluate", "Evaluate");
    
        foreach (DataGridViewRow ThisRow in dtgBangketqua.Rows)
        {
            string strAge = ThisRow.Cells[1].Value as string;
            int Age = -1;
            if( int.TryParse(strAge,out Age) == true )
            {
                ThisRow.Cells[2].Value = (Age < 40) ? "Young" : "Old";
            }
        }
    }
