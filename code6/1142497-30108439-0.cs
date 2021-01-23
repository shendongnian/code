    Point pt;
    int y = 20;
    int x = 0;
    for (int i = 0; i < 16; i++)
    {
       x = 20;
       for (int j = 1; j <= 4; j++)
       {
          pt = new Point(x, y);
          Button btn = new Button() { Location = pt, Size = new Size(75, 23) };
          btn.Name = i.ToString() + j.ToString();
          btn.Text = string.Format("{0} {1:D2}", "Seat", i * 4 + j);
          panel1.Controls.Add(btn);
          x += 90;
        }
        y += 30;
     }
