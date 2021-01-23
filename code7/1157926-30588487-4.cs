    //global variable and preferably initialize in the constructor or OnLoad Event
    List<string> mystringlist = new List<string>();
    
    void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tb = (TextBox)sender;
                if(mystringlist.Count >= 5)
                {
                    this.dataGridView1.Rows.Add(mystringlist.ToArray());
                    mystringlist.Clear();
                }
                mystringlist.Add(tb.Text);            
                tb.Clear();
            }
        }
