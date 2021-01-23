    // add space for two lines:
    dataGridView1.Rows[0].Height = ((Image)dataGridView1[0, 0].Value).Height + 35;
    // if the previous line throws an error..
    // .. because you didn't put a 'real image' into the cell try this:
    // dataGridView1.Rows[0].Height = 
         ((Image)dataGridView1[0, 0]. FormattedValue).Height + 35;
 
    // align the image top left:
    dataGridView2[0, 0].Style.Alignment = DataGridViewContentAlignment.TopLeft;
