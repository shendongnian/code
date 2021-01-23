    if (dgridEmployees.CurrentRow.Cells[6].Value == DBNull.Value)
    {
        byte[] img = (byte[])dgridEmployees.CurrentRow.Cells[6].Value;
        MemoryStream ms = new MemoryStream(img);
        pictureBox1.Image = Image.FromStream(ms);
    }
    else
    {
        pictureBox1.Image = null;
    }
