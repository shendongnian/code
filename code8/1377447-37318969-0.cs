	DataSet ds1 = DataUtils.GetQuoteDetails((int.Parse(Request.QueryString["QuoteID"])), Company.Current.CompanyID);
	DataTable dt = ds1.Tables(0);
	foreach (DataColumn dc in dt.Columns) {
		switch (dc.ColumnName) {
			case "Approved1":
			case "Approved2":
			case "Approved3":	//-- add more column names here that you want to check
				DataRow[] approvedRows = dt.Select(dc.ColumnName + " = 1");
				if (approvedRows.Length > 1) {
					//-- this is the case you are looking for... this column has more than one rows selected
					//-- I am showng a messagebox.. you may do other custom handling here..
					string msg = string.Format("Column \"{0}\" has {1} selections, which is not allowed!", dc.ColumnName, approvedRows.Length);
					MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return; // we don't want to show any more messageboxes.
				}
				break;
		}
	}
