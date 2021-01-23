    using System;
    using System.Data;
    using System.Windows.Forms;
    //my additions
    using System.Data.SqlServerCe;
    using System.IO;
    namespace DataProg15
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public static string form1DatabasePath = "C:\\DbTemp\\dbtemp1.sdf";
            public static string form1ConnectionString = "Data Source = " +form1DatabasePath;
            private void btnCreateDb_Click(object sender, EventArgs e)
            {
                    SqlCeEngine engine = new SqlCeEngine(form1ConnectionString);
                try
                {
                    engine.CreateDatabase();
                    MessageBox.Show("DataBase '" +form1DatabasePath+ "' was created successfully");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Exception in CreateDatabase " + ex.ToString(), "Exception in CreateDatabase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    engine.Dispose();
                }
            }
            private void btnDeleteDb_Click(object sender, EventArgs e)
            {
                if (File.Exists(form1DatabasePath))
                {
                    try
                    {
                        File.Delete(form1DatabasePath);
                        MessageBox.Show("DataBase '" +form1DatabasePath+ "' was deleted successfully");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Exception in DeleteDatabase '" +form1DatabasePath+ "'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            private void btnDoesDbExist_Click(object sender, EventArgs e)
            {
                if (File.Exists(form1DatabasePath))
                {
                        MessageBox.Show("DataBase '" +form1DatabasePath+ "' exists");
                }
                else
                {
                        MessageBox.Show("DataBase '" +form1DatabasePath+ "' does not exist");
                }
            }
        }
    }
