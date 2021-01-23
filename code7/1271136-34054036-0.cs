    System.Windows.Forms.TextBox[] someTb = new System.Windows.Forms.TextBox[10];
    for (int i = 0; i < 10; ++i)
    {
    sombeTb[i] = new TextBox();
    someTb[i].Location = new System.Drawing.Point(60, 84 + i * 35);
    this.Controls.Add(someTb[i]);
    someTb[i].Name = "someName" + i.ToString();
    }
