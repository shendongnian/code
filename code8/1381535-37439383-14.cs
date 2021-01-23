    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    using System.IO;
    using System.Data;
    using System.Data.OleDb;
    
    using System.Data.SqlClient;
    using System.Data;
    
    namespace WebApplication1
    {
        public partial class EmployeeImport : System.Web.UI.Page
        {
            public string GetDateTimeStampedFolderName()
            {
                return string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            }
    
            public void CreateSchemIni(string targetFolder, string fileName)
            {
                using (FileStream filestr = new FileStream(targetFolder + "/schema.ini", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(filestr))
                    {
                        writer.WriteLine("[" + FileUpload1.FileName + "]");
                        writer.WriteLine("ColNameHeader=True");
                        writer.WriteLine("Format=CSVDelimited");
                        writer.WriteLine("Col1=FirstName Text");
                        writer.WriteLine("Col2=LastName Text");
                        writer.WriteLine("Col3=\"Hire Date\" Text");
                        writer.Close();
                        writer.Dispose();
                    }
                    filestr.Close();
                    filestr.Dispose();
                }
            }
    
            private bool ValidateHeaders(DataTable importData, DataTable importDataSourceSchema)
            {
    
                bool isValid = true;
    
                if (importData.Columns.Count != importDataSourceSchema.Columns.Count)
                {
                    isValid = false;
                    ValidationLabel.Text = ValidationLabel.Text + "<br />Wrong number of columns";
                }
    
                for (int i = 0; i < importData.Columns.Count; i++)
                {
                    if (importData.Columns[i].ColumnName != importDataSourceSchema.Columns[i].ColumnName)
                    {
                        ValidationLabel.Text = ValidationLabel.Text + "<br />Error finding column " + importData.Columns[i].ColumnName;
                        isValid = false;
                    }
                }
    
                return isValid;
            }
    
            private void UploadAndImport()
            {
                if (FileUpload1.HasFile)
                {
                    string targetFolder = Server.MapPath("~/Uploads/Employees/" + GetDateTimeStampedFolderName());
    
                    if (System.IO.Directory.Exists(targetFolder) == false)
                    {
                        System.IO.Directory.CreateDirectory(targetFolder);
                    }
    
                    FileUpload1.SaveAs(Path.Combine(targetFolder, FileUpload1.FileName));
                    
                    
    
                    string strSql = "SELECT * FROM [" + FileUpload1.FileName + "]";
                    string strCSVConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + targetFolder + ";" + "Extended Properties='text;HDR=YES;'";
                    using (OleDbDataAdapter oleda = new OleDbDataAdapter(strSql, strCSVConnString))
                    {
                        DataTable importData = new DataTable();
                        DataTable importDataSourceSchema = new DataTable();
                        
                        // Fill the schema prior to creating the schema.ini, as this is the only way to get the headers from the CSV
                        oleda.FillSchema(importDataSourceSchema, System.Data.SchemaType.Source);
                        CreateSchemIni(targetFolder, FileUpload1.FileName);
                        oleda.Fill(importData);
    
                        if (ValidateHeaders(importData, importDataSourceSchema))
                        {
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy([Add your ConnectionString here], SqlBulkCopyOptions.TableLock))
                            {
                                bulkCopy.DestinationTableName = "dbo.EmployeeImport";
                                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("FirstName", "FirstName"));
                                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("LastName", "LastName"));
                                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Hire Date", "HireDate"));
                                try
                                {
                                    bulkCopy.WriteToServer(importData);
                                    ValidationLabel.Text = "Success";
                                    GridView1.DataSource = importData;
                                    GridView1.DataBind();
                                }
                                catch (Exception e)
                                {
                                    ValidationLabel.Text = e.Message;
                                }
                            }
    
                            
                        }
                    }
                }
            }
    
            protected void UploadButton_Click(object sender, EventArgs e)
            {
                if (FileUpload1.HasFile)
                {
                    ValidationLabel.Text = "";
                    UploadAndImport();
                }
            }
        }
    }
