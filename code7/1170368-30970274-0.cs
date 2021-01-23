    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SQLite;
    using MySql.Data.MySqlClient;
    
    
    namespace SampleConversion
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        private void create_SQLite_database()
        {
            string connectionString = "Data Source=" + Application.StartupPath + "\\pthData.sqlite;Version=3;";
            try
            {
                SQLiteConnection.CreateFile("pthData.sqlite");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Unable to create the SQLite database\n" + ex.Message + "\nConnection string: " + connectionString, "Create SQLite file/database error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create the SQLitedatabase\n" + ex.Message + "\nConnection string: " + connectionString, "Create SQLite file/database error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            // file created, now create tables
            SQLiteConnection cn = new SQLiteConnection(connectionString);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            SQLiteCommand cmd;
            string commandString = "Create table if not exists USTimeZones\n";
            // create time zones file
            commandString += "(state nvarchar(30), city nvarchar(100), county nvarchar(50), timezone nvarchar(10), ";
            commandString += "timetype int, latitude nvarchar(10), longitude nvarchar(10),  ";
            commandString += "PRIMARY KEY(state, city, county, timezone, timetype))";
            cmd = new SQLiteCommand(commandString, cn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException sqlexception)
            {
                MessageBox.Show(sqlexception.Message + "\n Command string: " + commandString, "Error creating USTimeZones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Command string: " + commandString, "Error creating USTimeZoness", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }
        private void btnMySql_Click(object sender, EventArgs e)
        {
            string cmd = "";
            int count = 0;
            create_SQLite_database(); // Create the SQLite database file and a table within it
            string MySQLconnectionString = "Server=MyServerAddress;Database=PTHData;uid=username;pwd=passwordhere;database=USTimeZones";
            string SQLiteconnectionString = "Data Source=" + Application.StartupPath + "\\pthData.sqlite;Version=3;";
            // open the input and output database
            SQLiteConnection SQLiteconnection = new SQLiteConnection(SQLiteconnectionString);
            try
            {
                SQLiteconnection.Open();
            }
            catch (SQLiteException ex)
            {
                string errorMessages = "A SQLite exception occurred on open.\n" + ex.Message;
                MessageBox.Show(errorMessages, "Convert");
                return;
            }
            MySqlConnection MySQLconnection = new MySqlConnection(MySQLconnectionString);
            try
            {
                MySQLconnection.Open();
            }
            catch (SqlException ex)
            {
                string errorMessages = "A MySQL exception occurred on open.\n" + ex.Message;
                MessageBox.Show(errorMessages, "Convert");
                return;
            }
            //Databases are not open, time to convert
            MySqlCommand cmdread = new MySqlCommand();
            cmdread.Connection = MySQLconnection;
            cmdread.CommandText = "Select * from USTimeZones";
            MySqlDataReader drread = null;
            SQLiteCommand cmdwrite = new SQLiteCommand();
            cmdwrite.Connection = SQLiteconnection;
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
                    catch (SQLiteException ex)
                    {
                        string errorMessages = "An SQL exception occurred on writing the SQLite record.\n" + ex.Message;
                        MessageBox.Show(errorMessages, "Convert");
                        SQLiteconnection.Close();
                        MySQLconnection.Close();
                        return;
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorMessages = "A MySQL exception occurred reading records.\n" + ex.Message;
                MessageBox.Show(errorMessages, "Convert");
            }
            catch (Exception ex)
            {
                string errorMessages = "A General exception occurred reading records.\n" + ex.Message;
                MessageBox.Show(errorMessages, "Convert");
            }
            MessageBox.Show("Records written: " + count.ToString(), "Conversion complete");
            drread.Close();
            MySQLconnection.Close();
            SQLiteconnection.Close();
        }
    }
