    f2.Text = this.dataGridView1.CurrentCell.Value.ToString();
    f2.RowIndex = this.dataGridView1.CurrentCell.RowIndex; 
    f2.ColumnIndex = this.dataGridView1.CurrentCell.RowIndex;
    public class Form2
    {
        public Int32 RowIndex {get; set;}
        // ...
        
       
    }
