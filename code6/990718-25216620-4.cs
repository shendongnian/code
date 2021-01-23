    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public string myConnectionString = @"DataSource =.\SQLEXPRESS;AttachDbFileName=myconnection.mdf;Integrated Security=true;"
    
            private void Form1_Load(object sender, EventArgs e)
            {
                FillCombo();
            }
    
            private void FillCombo()
            {
                SqlConnection dbConnection = new SqlConnection(myConnectionString);
                SqlCommand sqlCmd = new SqlCommand();
                try
                {
                    
                    sqlCmd.Connection = dbConnection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "use database_name; SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';";
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);
                    comboBox1.DataSource = dtRecord;
                    comboBox1.DisplayMember = "TABLE_NAME";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                dbConnection.Close();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection dbConnection = new SqlConnection(myConnectionString);
                string myCommand = "CREATE TABLE["+textBox1.Text+"] (column1 VARCHAR(10),colunm2 INT)";
                SqlCommand dbCommand = new SqlCommand(myCommand, dbConnection);
                try
                   {
                      dbConnection.Open();
                      dbCommand.ExecuteNonQuery();
                      FillCombo();
                   }
    
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                dbConnection.Close();
             }
            }
    }
