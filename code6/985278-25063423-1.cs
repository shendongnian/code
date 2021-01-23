    var path = accView.Rows[e.RowIndex].Cells[10].Value;
    if (string.IsNullOrEmpty(path))
    {
        //set the default path
        path = ....
    }
    
    accPictureBox.Image = Image.FromFile(path, true)
