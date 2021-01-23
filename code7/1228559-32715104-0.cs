    private void PrintsDoc (object sender, PrintPageEventArgs e)
    {
        Graphics g = e.Graphics;
        StringFormat sf = new StringFormat ();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Near;
    
        Font fontStyle = new Font ("Times New Roman", 30);
        Font fontStyle2 = new Font ("Times New Roman", 10);
        g.DrawString ("Trade Confirmation", fontStyle, Brushes.Black, e.MarginBounds, sf);
        g.DrawString ("\n\n\nTrade Date: " + dt + "\nPrint Date: " + DateTime.Now.ToString (), fontStyle2, Brushes.Black, e.MarginBounds, sf);
    
        using (SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=database;Trusted_Connection=yes;"))
        using (SqlCommand cmd = new SqlCommand("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TRADE'", conn))
        {
        conn.Open ();
        int i = 0, j = 0;
        SqlDataReader rdr = cmd.ExecuteReader ();
        while (rdr.Read ()) {
            Rectangle rec = new Rectangle (new Point (40 + i, 250), new Size (200, 25));
            g.DrawRectangle (Pens.Black, rec);
            //g.DrawString (rdr.GetString(0 + j), fontStyle2, Brushes.Black, rec, sf);
            g.DrawString ((string)rdr["COLUMN_NAME"], fontStyle2, Brushes.Black, rec, sf);
            i = i + 215;
            j = j + 1; // what is the purpose of j?
        }
    
        e.HasMorePages = false;
        conn.Close ();
        }
    }
