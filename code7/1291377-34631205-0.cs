    using System;
    using System.Data;
    using System.Data.OleDb;
    
    namespace ExcelReadRangeSimple
    {
        internal class Program
        {
            /// <summary>
            /// This functiuon is an example of how you can setup a connection for an
            /// Excel file based on the extension.
            /// </summary>
            /// <param name="FileName"></param>
            /// <param name="Header"></param>
            /// <returns></returns>
            /// <remarks>
            ///  There are no guaranty that the settings below will be correct for
            ///  your Excel file. Things to tweak if it does not work
            ///  
            ///  - IMEX
            ///  - HDR
            ///  
            ///  SeeAlso for IMEX
            ///  http://www.codeproject.com/Articles/37055/Working-with-MS-Excel-xls-xlsx-Using-MDAC-and-Oled
            /// </remarks>
            static public string ConnectionString(string FileName, string Header)
            {
                OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder();
                if (System.IO.Path.GetExtension(FileName).ToUpper() == ".XLS")
                {
                    Builder.Provider = "Microsoft.Jet.OLEDB.4.0";
                    Builder.Add("Extended Properties", string.Format("Excel 8.0;IMEX=1;HDR={0};", Header));
                }
                else
                {
                    Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
                    Builder.Add("Extended Properties", string.Format("Excel 12.0;IMEX=1;HDR={0};", Header));
                }
    
                Builder.DataSource = FileName;
                           
                return Builder.ConnectionString;
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="FileName">Full path and file name to read</param>
            /// <param name="SheetName">Name of sheet to read, do not append $</param>
            /// <param name="StartCell">Cell to start range i.e. A1</param>
            /// <param name="EndCell">Cell to end range i.e. D30</param>
            static private void DemoReadData(string FileName, string SheetName, string StartCell, string EndCell)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                DataTable dt = new DataTable();
    
                using (OleDbConnection cn = new OleDbConnection { ConnectionString = ConnectionString(FileName, "No") })
                {
                    cn.Open();
    
                    string SelectStatement = string.Format("SELECT F1 As Company, F2 As Contact FROM [{0}${1}:{2}]", SheetName, StartCell, EndCell);
    
                    using (OleDbCommand cmd = new OleDbCommand { CommandText = SelectStatement, Connection = cn })
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine("Connection string is");
                        Console.WriteLine(cn.ConnectionString);
                        Console.WriteLine();
                        Console.WriteLine();
    
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Console.WriteLine("   {0,-25} {1}", dr.GetString(1), dr.GetString(0));
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows!!!");
                        }
                    }
                }
    
    
    
            }
            private static void Main(string[] args)
            {
                string FileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WS1.xlsx");
    
                DemoReadData(FileName, "Sheet4", "C7", "D16");
                Console.ReadLine();
            }
        }
    }
