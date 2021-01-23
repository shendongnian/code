	protected void BtnGetData_Click(object sender, EventArgs e)
	{   
		string dateFrom = datepickerfrom.Text;  //  -- updated 
		string dateTo = datepickerto.Text;      //  -- updated 
		InputData data = new InputData(dateFrom, dateTo);
		Session["inputData"] = data;
		gvErrorLog.PageIndex = 0;
		LoadLogErrorData(data);  
	}
