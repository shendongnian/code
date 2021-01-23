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
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Initially your DataGridView will not have a DataSource to display your data so you need
                // to define a DataTable that will be used as the DataSource for you DataGridView
                var dt = new DataTable();
                // Add the desired columns to it, with their headers and data types
                dt.Columns.Add(new DataColumn("Id", typeof(int)));
                dt.Columns.Add(new DataColumn("Description", typeof(string)));
                
                // You can add new rows to your DataTable using the DataTable object itself
                // in order to create DataRows with the exact DataColumns required for that DataTable
                var newRow = dt.NewRow();
                newRow["Id"] = 1;
                newRow["Description"] = "Desc 1";
                // And then you simply add this new row to your DataTable
                dt.Rows.Add(newRow);
    
                newRow = dt.NewRow();
                newRow["Id"] = 2;
                newRow["Description"] = "Desc 2";
                dt.Rows.Add(newRow);
    
                newRow = dt.NewRow();
                newRow["Id"] = 3;
                newRow["Description"] = "Desc 3";
                dt.Rows.Add(newRow);
    
                // By the end you set the DataSource property of your DataGridView
                // assigning to it the DataTable you created
                dataGridView1.DataSource = dt;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                // In order to add new rows to your DataGridView with the current DataTable
                // you simply need to take it back from the DataGridView.DataSource property by casting it
                // to a DataTable again
                var dt = (DataTable)dataGridView1.DataSource;
    
                // And then you add the new rows in the same way that were shown in the Click event for button1
                var newRow = dt.NewRow();
                newRow["Id"] = 4;
                newRow["Description"] = "Desc 4";
                dt.Rows.Add(newRow);
    
                newRow = dt.NewRow();
                newRow["Id"] = 5;
                newRow["Description"] = "Desc 5";
                dt.Rows.Add(newRow);
            }
        }
    }
