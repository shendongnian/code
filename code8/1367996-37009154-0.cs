    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.OleDb;
    using System.Globalization;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.DataSource = CsvFileToDatatable(@"C:\Users\xxx\test.csv", false);
            }
    
    
            public DataTable CsvFileToDatatable(string path, bool IsFirstRowHeader) //here Path is root of file and IsFirstRowHeader is header is there or not
            {
                string header = "No";
                string sql = string.Empty;
                DataTable dataTable = null;
                string pathOnly = string.Empty;
                string fileName = string.Empty;
    
                try
                {
    
                    pathOnly = Path.GetDirectoryName(path);
                    fileName = Path.GetFileName(path);
    
                    sql = @"SELECT * FROM [" + fileName + "]";
    
                    if (IsFirstRowHeader)
                    {
                        header = "Yes";
                    }
    
                    using (OleDbConnection connection = new OleDbConnection(
                            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                            ";Extended Properties=\"Text;HDR=" + header + "\""))
                    {
                        using (OleDbCommand command = new OleDbCommand(sql, connection))
                        {
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                            {
                                dataTable = new DataTable();
                                dataTable.Locale = CultureInfo.CurrentCulture;
                                adapter.Fill(dataTable);
    
                            }
                        }
                    }
                }
                finally
                {
    
                }
    
                return dataTable;
    
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '{0}%'", textBox1.Text);
            }
        }
    }
