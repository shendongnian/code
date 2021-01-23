     public DataTable dat = new DataTable();
     public DataTable GetFromMainForm(DataTable dt) {
                this.dat = dt;
                return dat;
            }
    
            private DataTable GetFromMainForm() {
                return dat;
            }
 
    private void NDokButton_Click(object sender, EventArgs e)
            {
                DataTable dt = GetFromMainForm();
                var n = dt.Rows[0].ItemArray[0];
                String a = n.ToString();
                MessageBox.Show(a);
    
            }
