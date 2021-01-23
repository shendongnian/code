    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Data.SqlServerCe;
    
    
    namespace SampleConversion
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btnConvert_Click(object sender, EventArgs e)
            {
                string cmd = "";
                int count = 0;
    
                create_SQLCE_database(); // Create the SQLCE database file and a table within it
    
                string SQLconnectionString = "server=(local); database=PTHData; Trusted_Connection=True;"; // open PTHData.mdf
                string SQLCEconnectionString = "Data Source=" + Application.StartupPath + "\\pthData.sdf;Persist Security Info=False"; // open PTHDATA.sdf
    
                // open the input and output database
                SqlCeConnection SQLCEconnection = new SqlCeConnection(SQLCEconnectionString);
                try
                {
                    SQLCEconnection.Open();
                }
                catch (SqlCeException ex)
                {
                    string errorMessages = "A SQLCE exception occurred on open.\n" + ex.Message;
                    MessageBox.Show(errorMessages, "Convert");
                    return;
                }
                SqlConnection SQLconnection = new SqlConnection(SQLconnectionString);
                try
                {
                    SQLconnection.Open();
                }
                catch (SqlException ex)
                {
                    string errorMessages = "A SQL exception occurred on open.\n" + ex.Message;
                    MessageBox.Show( errorMessages, "Convert");
                    return;
                }
    
                //Databases are not open, time to convert
                SqlCommand cmdread = new SqlCommand();
                cmdread.Connection = SQLconnection;
                cmdread.CommandText = "Select * from USTimeZones";
                SqlDataReader drread = null;
    
                SqlCeCommand cmdwrite = new SqlCeCommand();
                cmdwrite.Connection = SQLCEconnection;
    
                try
                {
                    drread = cmdread.ExecuteReader();
                    while (drread.Read())
                    {
                        drread["timezone"].ToString();
                        cmd = "Insert into USTimeZones values ('" + drread["state"].ToString() + "','" +
                            drread["city"].ToString() + "','" + drread["county"].ToString() + "','" +
                            drread["timezone"].ToString() + "','" + drread["timetype"].ToString() + "','" +
                            drread["latitude"].ToString() + "','" + drread["longitude"].ToString() + "')";
                        cmdwrite.CommandText = cmd;
                        try
                        {
                            cmdwrite.ExecuteNonQuery();
                            count++;
                        }
                        catch (SqlCeException ex)
                        {
                            string errorMessages = "An SQL exception occurred on writing the SQLCE record.\n" + ex.Message;
                            MessageBox.Show(errorMessages, "Convert");
                            SQLCEconnection.Close();
                            SQLconnection.Close();
                            return;
                        }
    
                    }
                }
                catch (SqlException ex)
                {
                    string errorMessages = "A SQL exception occurred reading records.\n" + ex.Message;
                    MessageBox.Show(errorMessages, "Convert");
                }
                catch (Exception ex)
                {
                    string errorMessages = "A General exception occurred reading records.\n" + ex.Message;
                    MessageBox.Show(errorMessages, "Convert");
                }
    
                MessageBox.Show("Records written: " + count.ToString(), "Conversion complete");
                drread.Close();
                SQLconnection.Close();
                SQLCEconnection.Close();
     
            
            }
            private void create_SQLCE_database()
            {
                string connectionString = "Data Source=" + Application.StartupPath + "\\pthData.sdf;Persist Security Info=False";
                
                try
                {
                    SqlCeEngine en = new SqlCeEngine(connectionString);
                    en.CreateDatabase();
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show("Unable to create the SQLCE pthData database\n" + ex.Message, "Create SQLCE file/database error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to create the SQLCE pthData database\n" + ex.Message, "Create SQLCE file/database error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                // file created, now create tables
                SqlCeConnection cn = new SqlCeConnection(connectionString);
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
    
                SqlCeCommand cmd;
                string commandString = "Create table USTimeZones\n";
    
    
                // create USTimeZones file
                commandString = "Create table USTimeZones\r\n";
                commandString += "(state nvarchar(30), city nvarchar(100), county nvarchar(50), timezone nvarchar(10), ";
                commandString += "timetype int, latitude nvarchar(10), longitude nvarchar(10),  ";
                commandString += "PRIMARY KEY(state, city, county, timezone, timetype))";
                cmd = new SqlCeCommand(commandString, cn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlCeException sqlexception)
                {
                    MessageBox.Show(sqlexception.Message + "\n Command string: " + commandString, "Error creating USTimeZoness", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error creating USTimeZones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
    
    
                cn.Close();
            }
    
        }
    }
