    Bitmap img;
    
    img = new Bitmap(@"c:\images\mousepad.jpg");
    
    // Create the DGV with an Image column
    
    DataGridView dgv = new DataGridView();
    
    this.Controls.Add(dgv);
    
    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
    
    dgv.Columns.Add(imageCol);
    
    // Add a row and set its value to the image
    
    dgv.Rows.Add();
    
    dgv.Rows[0].Cells[0].Value = img;
