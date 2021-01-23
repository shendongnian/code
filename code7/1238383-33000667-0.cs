    using Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO; 
    using System.Text; 
    public static DataTable LoadDataTable(string filePath)
            {
                string fileExtension = Path.GetExtension(filePath);
                switch (fileExtension.ToLower())
                {
                    case ".xlsx":
                        return ConvertExcelToDataTable(filePath, true);
                    case ".xls":
                        return ConvertExcelToDataTable(filePath);
                    case ".csv":
                        return ConvertCsvToDataTable(filePath);
                    default:
                        return new DataTable();
                }
    
            }
 
    public static DataTable ConvertExcelToDataTable(string filePath, bool isXlsx = false)
            {
                FileStream stream = null;
                IExcelDataReader excelReader = null;
                DataTable dataTable = null;
                stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                excelReader = isXlsx ? ExcelReaderFactory.CreateOpenXmlReader(stream) : ExcelReaderFactory.CreateBinaryReader(stream);
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                if (result != null && result.Tables.Count > 0)
                    dataTable = result.Tables[0];
                return dataTable;
            }
    public static DataTable ConvertCsvToDataTable(string filePath)
            {
                DataTable dt = new DataTable();
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
    
                }
                return dt;
            }
