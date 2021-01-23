    Bitmap diplomaBackground = null;  // load upon startup
    Bitmap result = null;
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (result != null)
        {
            if (pb_preview.Image != null) pb_preview.Image = null;
            result.Dispose();
        }
        if (dataGridView1.SelectedRows.Count > 0)
        {
            result = CreateNewDiploma(dataGridView1.SelectedRows[0].Index);
            pb_preview.Image = result;
        }
    }
    Bitmap CreateNewDiploma(int rowIndex)
    {
        Bitmap bmp = new Bitmap(diplomaBackground);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            // draw the data..
        }
        return bmp;
    }
