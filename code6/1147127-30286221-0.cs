    while (reader.Read())
    {
        System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
        txt.Top = (cLeft*25) + 124;
        txt.Left = 50;
        txt.Height = 20;
        txt.Width = 259;
        txt.Text=reader["Pertanyaan"].ToString();
        if (txt.Text=="")
        {
            MessageBox.Show("Pertanyaan  Habis , Akan Redirect Ke Hasil");
        }
        this.Controls.Add(txt);
    }
