    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace App1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string strcmd2 = "Select Food_Name,Food_ID from dbo.TblFood_Food ";
            //Dt2 = Dbc.seletcmd(strcmd2);
            //fabricate some data....
            List<Food> Foods = new List<Food>();
            
            Foods.Add(new Food() { Food_ID = "0", Food_Name = "NONE" });
            Foods.Add(new Food() { Food_ID = "1", Food_Name = "Burger" });
            Foods.Add(new Food() { Food_ID = "2", Food_Name = "Fries" });
            DataGridViewComboBoxColumn ColumnAcc = new DataGridViewComboBoxColumn();
            ColumnAcc.DataPropertyName = "combo";
            ColumnAcc.HeaderText = "Food";
            ColumnAcc.Name = "Food";
            ColumnAcc.DataSource = Foods;
            ColumnAcc.DisplayMember = "Food_Name";
            ColumnAcc.ValueMember = "Food_ID";
            DataGridview_Food.Columns.Insert(0, ColumnAcc);
            DataGridview_Food.EditingControlShowing += DataGridview_Food_EditingControlShowing;
        }
        private void DataGridview_Food_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 0)
            {
                ComboBox cmb = e.Control as ComboBox;
                if (cmb != null)
                {
                    // remove the current event handler
                    cmb.SelectionChangeCommitted -= new EventHandler(cmb_SelectionChanged);
                    // now re-attach the event handler
                    cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChanged);
                }
            }
        }
        private void cmb_SelectionChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            Food selectedFood = (Food)cmb.SelectedItem;
            MessageBox.Show(string.Format("You selected item {0} ---> {1}", selectedFood.Food_ID, selectedFood.Food_Name));
        }    
    }
    }
    class Food
    {
        public string Food_Name { get; set; }
        public string Food_ID { get; set; }
    }
