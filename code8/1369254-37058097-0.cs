    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    
    namespace InventoryManager
    {
        public partial class frmAdjustment : Form
        {
            frmAmendStock _main;
    
            public string enteredSKU { get; set; }
    
            public frmAdjustment(frmAmendStock main)
            {
                InitializeComponent();
                _main = main;
            }        
            
            private void frmAdjustment_Load(object sender, EventArgs e)
            {
                this.AcceptButton = btnSubmit;
            }
    
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void btnSubmit_Click(object sender, EventArgs e)
            {
                using (OleDbConnection connect = new OleDbConnection())
                {
    
                    connect.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Other\Documents\University Work\USB\Individual Project\Artefact\InventoryManager\InventoryManager\stock.mdb";
                    connect.Open();
    
                    OleDbCommand cmd = new OleDbCommand("UPDATE items SET Stock = @stock, Stock_Counted = @counted WHERE SKU LIKE '" +enteredSKU+"'", connect);
                    string units = txtAmount.Text;
    
                        if (connect.State == ConnectionState.Open)
                        {
                            if (string.IsNullOrEmpty(units))
                            {
                                MessageBox.Show("Please enter the correct amount of units.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                cmd.Parameters.Add("@stock", OleDbType.Integer, 5).Value = txtAmount.Text;
                                cmd.Parameters.Add("@counted", OleDbType.Integer, 5).Value = txtAmount.Text;
    
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Stock Adjusted", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
                                    txtAmount.Clear();
    
                                    connect.Close();
                                }
                                catch (Exception expe)
                                {
                                    MessageBox.Show(expe.ToString());
                                    connect.Close();
                                }
                          }
                    }
                    else
                    {
                        MessageBox.Show("Connection Failed");
                    }
                }
            }
        }
    }
