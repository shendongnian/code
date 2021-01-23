    private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
    
            //Sets the Add New Button to Color WhiteSmoke
            this.button1.BackColor = Color.WhiteSmoke;
    
            //Hides current form (Form 1)
            this.Hide(); //<-- delete this
            //Displays Form 2
            f2.ShowDialog();
            f2.Dispose(); //<--  nessesary then using ShowDialog()
    
        }
