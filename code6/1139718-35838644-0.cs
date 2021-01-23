    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using MySql.Data.MySqlClient;
    // Download the above to add as assembly reference
    
    ///////////////////////////////////////////////
    
      ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
      String ConnectionString = "SERVER=localhost;DATABASE=excelmaps;UID=root;PASSWORD=;";
                    MySqlConnection connection = new MySqlConnection(ConnectionString);
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * FROM `sheet1`", connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
    DataTable dt = new DataTable();
    
                    dt.Load(reader);
    
                    DataRow row1 = dt.NewRow();
    
                    int cnt = 0;
      worksheet.Cells["A1"].LoadFromDataTable(dt, true);
     package.Save();
    
        }
            }
