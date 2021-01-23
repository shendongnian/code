    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                DataTable dt = new DataTable();
    
                DataColumn dc1 = new DataColumn("id", typeof(System.Int32));
                DataColumn dc2 = new DataColumn("desc", typeof(System.String));
    
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
    
                for (int i = 0; i < 5; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = i;
                    dr["desc"] = i.ToString() + " desc";
    
                    dt.Rows.Add(dr);
                }
    
    
                toolStripComboBox1.ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
    
                toolStripComboBox1.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
    
                toolStripComboBox1.ComboBox.ValueMember = "id";
                toolStripComboBox1.ComboBox.DisplayMember = "desc";
                toolStripComboBox1.ComboBox.DataSource = dt;
    
    
            }
    
            private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
            {
                //throw new NotImplementedException();
                int v = Int32.Parse(((DataRowView)toolStripComboBox1.ComboBox.SelectedItem)["id"].ToString());
    
                MessageBox.Show("User Selected " + v.ToString());
            }
    
            private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                //this line will give you the 
    
    
            }
    
            private void toolStripComboBox1_Click(object sender, EventArgs e)
            {
    
            }
        }
    }
