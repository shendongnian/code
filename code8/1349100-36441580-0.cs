    public partial class KnowledgeBaseForm : Form
        {
         SqlDataAdapter SDA = new SqlDataAdapter();
         DataTable DT = new DataTable();
         DataSet ds = new DataSet();
        private void button_retrievekb_Click(object sender, EventArgs e)
                {
        
                   SDA = new SqlDataAdapter(@"SELECT * From Table1", con);
                   ds = new DataSet();
                   SDA.fill(ds,"SomeName");
                   dataGridView1.DataSource = ds.Tables[0];
                }
        
        private void button_update_Click(object sender, EventArgs e)
              {
        
        
                if (MessageBox.Show("Do you really want to Update these values?", "Confirm Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
                   SDA.Update(ds,"SomeNme");
        
                }
              }
        }
