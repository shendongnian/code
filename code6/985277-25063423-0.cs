    var path = accView.Rows[e.RowIndex].Cells[10].Value;
    if (!string.IsNullOrEmpty(path))
    {
        accPictureBox.Image = Image.FromFile(path, true)
    }
    else
    {
        //use the default path...
    }
