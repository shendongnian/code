    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    
    namespace WindowsFormsApplication1
    {
     public partial class Form5 : Form
        {
            public Form5()
            {
                InitializeComponent();
            }
    
            Thread dbThread;
          
            private void button1_Click(object sender, EventArgs e)
            {
                dbThread = new Thread(DbRead);
                dbThread.Start ();
            }
    
    
            void DbRead()
            {
                string myConnection = "datasource=s59.hekko.pl;port=3306;username=truex2_kuba;password=xxx";
                string Query = "insert into truex2_kuba.users (uid,password) values('" + uid.Text + "','" + pwd.Text + "');";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Użytkownik Stworzony");
                while (myReader.Read())
                {
    
                }
                myConn.Close();
    
            }
        }
    }
