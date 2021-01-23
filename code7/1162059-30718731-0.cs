    public Form1()
        {
            InitializeComponent();
            
        }
        
        public PDVCollection s;
        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = PDVCollection.GetAll();
            s = (StopaPDVCollection)bindingSource1.DataSource;
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        
            s = s.Save();
            bindingSource1.DataSource = s;
            
        }
        
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentCell.RowIndex > -1)
            {
                PDV sel = (PDV)dataGridView1.CurrentRow.DataBoundItem;
                
                s.Remove(sel);
                
            }
        }
      
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (s.IsDirty)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save changes", "Message", "Poruka", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    s = (PDVCollection)bindingSource1.DataSource;
                    s = s.Save();
                    bindingSource1.DataSource = s;
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            
        }
    }
