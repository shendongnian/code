	DataTable dtable = new DataTable();
	DataColumn dcol = new DataColumn("filepath");
	dtable.Columns.Add(dcol);
	DataRow drow = dtable.NewRow();
	string pat = new Uri(Server.MapPath("~/Content/DSC_019.jpg")).AbsoluteUri;
	drow["track_file_uuidName"] = pat;
	dtable.Rows.Add(drow);
	...
	ReportViewer1.LocalReport.EnableExternalImages = true;
	...
	ReportViewer1.LocalReport.DataSources.Clear();
	ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("rptDataSet", objCommonreport.ReportTable));
	ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtable));
