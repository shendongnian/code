    using System;
    using System.Data;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using System.IO;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            private MySqlDataAdapter mydtadp = new MySqlDataAdapter();
            private BindingSource bindingSource1 = new BindingSource();
            
            MySqlCommandBuilder cmbl;
            String MyConnection = "SERVER=hostname;" +
                        "DATABASE=dbname;" +
                        "UID=dbuser;" +
                        "PASSWORD=fffff";
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                MySqlConnection MyConn = new MySqlConnection(MyConnection);
                MyConn.Open();
                
                mydtadp.SelectCommand=new MySqlCommand("select * from aster_scripts", MyConn);
                cmbl = new MySqlCommandBuilder(mydtadp);
    
                DataTable table = new DataTable();
                mydtadp.Fill(table);
    
                bindingSource1.DataSource = table;
                dataGridView1.DataSource = bindingSource1;
            }
    
            private void BtnSave_Click(object sender, EventArgs e)
            {
                mydtadp.Update((DataTable)bindingSource1.DataSource);
    
                MessageBox.Show("SAVED");
            }
        }
    }
