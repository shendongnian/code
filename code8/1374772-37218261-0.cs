        using System.Data;
        using System.Data.OleDb;
        using System.IO;
        
        namespace App.Data
        {
            public class CsvFileHelper
            {
                public static DataTable ReadAsDataTable(string fileFullName)
                {
                    DataTable tableCSV;
        
                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + Path.GetDirectoryName(fileFullName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\""))
                    {
                        connection.Open();
        
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + Path.GetFileName(fileFullName), connection))
                        {
                            DataSet ds = new DataSet("CSVDataSet");
                            adapter.Fill(ds);
        
                            tableCSV = ds.Tables[0];
                        }
                    }
        
                    return tableCSV;
                }
            }
        }
