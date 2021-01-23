    //Clear any previous Def table
    if (calcDataSet.Tables.Contains("DS_Result") == true)
    {
        calcDataSet.Tables.Remove("DS_Result");
    }
    
    
    HYFY_UIResult(lanid, "H1", strtDt.ToString("01/MM/yyyy"), endDt.ToString("01/MM/yyyy"), conPer);
    
    
    if (calcDataSet.Tables["DS_Result"].Rows.Count == 0)
    {
        labelFirstHRes.Text = "-";
    }
    else
	{	
		DataRow[] DRow;
        DRow = calcDataSet.Tables["DS_Result"].Select("myid = '" + lanid + "'");
        labelFirstHRes.Text = DRow[0]["result"].ToString();
	}
