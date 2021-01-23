    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace multiplesheets_export
    {
        class Program
        {
        public static void Main(string[] args)
                    {
                        object missing = Type.Missing;
                        SqlConnection con = new SqlConnection("Data Source=WINCTRL-KJ8RKFO;Initial Catalog=excel;Integrated Security=True");
            
                        SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
                        SqlDataAdapter da1 = new SqlDataAdapter("select * from Department", con);
            
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();
            
                        da.Fill(dt);
                        da1.Fill(dt1);
            
                        if (dt == null || dt.Columns.Count == 0)
                                                            throw new Exception("ExportToExcel: Null or empty input table!\n");
                        Excel.Application oXL = new Excel.Application();
                        Excel.Workbook oWB = oXL.Workbooks.Add(missing);
                        Excel.Worksheet oSheet = oWB.ActiveSheet as Excel.Worksheet;
                        oSheet.Name = "Employee Details";
            
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            oSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                        }
                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            for (var j = 0; j < dt.Columns.Count; j++)
                            {
                                oSheet.Cells[i + 2, j + 1] = dt.Rows[i][j];
                            }
                        }
                       
                        // From Here am taking EXCEL SHEET -2
            
                        Excel.Worksheet oSheet2 = oWB.Sheets.Add(missing, missing, 1, missing)as Excel.Worksheet;
            
                        if (dt1 == null || dt1.Columns.Count == 0)
                            throw new Exception("ExportToExcel: Null or empty input table!\n");
                        oSheet2.Name = "Depatment Details";
            
                        for (var i = 0; i < dt1.Columns.Count; i++)
                        {
                            oSheet2.Cells[1, i + 1] = dt1.Columns[i].ColumnName;
                        }
                        for (var i = 0; i < dt1.Rows.Count; i++)
                        {
                            for (var j = 0; j < dt1.Columns.Count; j++)
                            {
                                oSheet2.Cells[i + 2, j + 1] = dt1.Rows[i][j];
                            }
                        }
                        oXL.Visible = true;
                    }
                }
            }
