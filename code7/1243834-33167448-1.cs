    $(document).ready(function () {
      $(document).keydown(function (event) {
          if (event.ctrlKey == true && (event.which == '107' || event.which == '109' || event.which == '187' || event.which == '189'))
           {
               event.preventDefault();
           }
       });
	   });
        protected void Button1_Click(object sender, EventArgs e)
        {               
            string path = "C:\\Pay.xls";
            string query = "SELECT * FROM [Sheet1$]";
            OleDbConnection conn = new OleDbConnection();
            if (File.Exists(path) == true)
            {
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = '" + path + "'" + @";Extended Properties=""Excel 8.0;HDR=NO;IMEX=1;ImportMixedTypes=Text;TypeGuessRows=0""";
                conn.Open();
                string ex_id = "";
                string colName = "";
                string colEmpID = "";
                string colBasic = "0";
                string colHRA = "0";
                string colConveyance = "0";
                try
                {
                    OleDbCommand ocmd = new OleDbCommand(query, conn);
                    OleDbDataReader odr = ocmd.ExecuteReader();
                    int nFields = odr.FieldCount;
                    DataTable dtable = new DataTable();
                    dtable.Load(odr);
                    if (dtable.Rows.Count > 0)
                    {
                        DataRow row = dtable.Rows[0];
                        if (GlobalCS.OpenConnection() == true)
                        {                            
                                for (int i = 5; i < dtable.Rows.Count; i++)
                                {
                                    row = dtable.Rows[i];
                                    ex_id = row[0].ToString();
                                    colEmpID = row[2].ToString();
                                    colName = row[1].ToString();
                                    colBasic = !string.IsNullOrEmpty(row[10].ToString()) ? row[10].ToString() : "0";
                                    colHRA = row[11].ToString();
                                    colConveyance = row[12].ToString();                                    
                                    if (colName != "")
                                    {
                                            sQuery = "insert into salary (EmployeeID,EmployeeName,Basics,DA,HRA,Conveyance,) values(@a,@b,@c,@d,@e,@f)";
                                                                                        cmd = new MySqlCommand(sQuery, GlobalCS.objMyCon);
                                            cmd.Parameters.AddWithValue("a", colEmpID);
                                            cmd.Parameters.AddWithValue("b", colName);
                                            cmd.Parameters.AddWithValue("c", colBasic);
                                            cmd.Parameters.AddWithValue("d", '0');
                                            cmd.Parameters.AddWithValue("e", colHRA);
                                            cmd.Parameters.AddWithValue("f", colConveyance);   
											rowsaffected = cmd.ExecuteNonQuery();
									} //close of if(colName!=0)
						} //close of for loop
                        }  // close of if(GlobalCS.Openconnection())
                    }  // close of if(dtable.Rows.Count > 0)
                    GlobalCS.CloseConnection();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    string display = ex.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                    GlobalCS.CloseConnection();                    
                    conn.Close();
                }
            }
            else  
            {
                string display = "Payslip.xls file not found";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                GlobalCS.CloseConnection();              
                conn.Close();
            }
