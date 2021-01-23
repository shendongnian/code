    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private static readonly DataTable MyData = new DataTable();
    
            public Form1()
            {
                InitializeComponent();
    
                //Assign the event handler
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var column1 = new DataColumn("privilege", Type.GetType("System.String"));
                var column2 = new DataColumn("username", Type.GetType("System.String"));
                var column3 = new DataColumn("password", Type.GetType("System.String"));
    
                MyData.Columns.Add(column1);
                MyData.Columns.Add(column2);
                MyData.Columns.Add(column3);
    
                var row0 = MyData.NewRow();
                row0["privilege"] = "Select an Item";
                row0["username"] = "";
                row0["password"] = "";
    
                var row1 = MyData.NewRow();
                row1["privilege"] = "admin";
                row1["username"] = "admin";
                row1["password"] = "8887abc";
    
                var row2 = MyData.NewRow();
                row2["privilege"] = "user";
                row2["username"] = "user1";
                row2["password"] = "abc123";
    
                MyData.Rows.Add(row0);
                MyData.Rows.Add(row1);
                MyData.Rows.Add(row2);
    
                comboBox1.DisplayMember = "privilege";
                comboBox1.ValueMember = "username";
                comboBox1.DataSource = MyData;
                comboBox1.SelectedIndex = 0;
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    var cb = (sender as ComboBox);
    
                    var selectedItem = (cb.SelectedItem as DataRowView);
    
                    label1.Text = selectedItem["username"].ToString();
                    label2.Text = selectedItem["password"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
        }
    }
