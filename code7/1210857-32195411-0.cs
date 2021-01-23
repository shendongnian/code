    List<dynamic[]> rows = new List<dynamic[]>();           
    rows.Add(new dynamic[] { "Cash", 500 });
    rows.Add(new dynamic[] { "Master Card", 1000 });
    rows.Add(new dynamic[] { "American Express", 10000 });
            
    Graphics g = e.Graphics;
    Font f = new Font("Courier New", 8f);
    //1st column
    StringFormat sf1 = new StringFormat();
    sf1.Alignment = StringAlignment.Near;
    sf1.LineAlignment = StringAlignment.Center;
    //2nd column
    StringFormat sf2 = new StringFormat();
    sf2.Alignment = StringAlignment.Far;
    sf2.LineAlignment = StringAlignment.Center;
    for (int i = 0; i < rows.Count; i++)
    {
        int x = 10; //Change for indentation (where you want the x position), currently 10px 
        int y = f.Height * i;
        int colWidth = 125; //You can change this to set each column's width
        Rectangle r1 = new Rectangle(x, y, colWidth, f.Height);
        Rectangle r2 = new Rectangle(r1.Right, y, colWidth, f.Height);
        g.DrawRectangle(Pens.Black, r1); //Just to debug rect area
        g.DrawRectangle(Pens.Black, r2);
        g.DrawString(rows[i][0], f, Brushes.Black, r1, sf1);
        g.DrawString(rows[i][1].ToString("0.00"), f, Brushes.Black, r2, sf2);
    }
