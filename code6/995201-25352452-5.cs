    private void button1_Click(object sender, EventArgs e)
    {
        this.Values[this.RowIndex][this.ColumnIndex] = textBox1.Text;
        string edit = String.Join(
            Environment.NewLine, 
            this.Values.
                Select(array => 
                    String.Join(",", array)).
                ToArray());
       
        File.WriteAllText(@"C:\Master.txt", edit);
        // ...        
    }
