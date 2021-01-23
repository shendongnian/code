    SqlConnection S_Conn = new SqlConnection(strConnString);
    S_Conn.Open();
    string query_1 = "";
    query_1 = "SELECT Record_Id, Select_Ward, Mr_No, Patient_Name, Date_Of_Admission, Date_Of_Dsch_Death, Disease "
            + "from EO_System_RecordRoomData WHERE Date_Of_Admission = '" + txtbx_DateForReport.Text.Trim() + "'";
    SqlCommand Command_1 = new SqlCommand(query_1, S_Conn);
    SqlDataAdapter Data_Adapter = new SqlDataAdapter(Command_1);
    DataSet1 Data_Set = new DataSet1();
    Data_Adapter.Fill(Data_Set);
    reportViewer1.LocalReport.DataSources.Clear();
    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Data_Set.Tables[1]));
    reportViewer1.RefreshReport();
    
    SaveFileDialog saveFileDialogPDF = new SaveFileDialog();
    saveFileDialogPDF.Filter = "PDF|*.pdf";
    saveFileDialogPDF.Title = "Save report to PDF";
    saveFileDialogPDF.ShowDialog();
    
    if (saveFileDialogPDF.FileName != "")
    {
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string filenameExtension;
    	byte[] bytes = reportViewer.LocalReport.Render(
                   "PDF", null, out mimeType, out encoding, out filenameExtension,
                   out streamids, out warnings);
    	using (FileStream fs = new FileStream(saveFileDialogPDF.FileName, FileMode.Create))
    	{
    		fs.Write(bytes, 0, bytes.Length);
    	}
    }
