    TextBox txt1 = new TextBox();
    TextBox txt2 = new TextBox();
    if (Cat0.Text == "test")
    {
         txt1.Name = "testText";
         txt1.Width = 170;
         txt1.Height = 21;
         txt1.Location = new System.Drawing.Point(122, 145);
         txt2.Name = "testText2";
         txt2.Width = 170;
         txt2.Height = 21;
         txt2.Location = new System.Drawing.Point(122, 171);
         panel1.Controls.Add(txt1);
         panel1.Controls.Add(txt2);
    }
    else
    {
         foreach (Control item in panel1.Controls)
         {
             if (item.Name == "testText")
             {
                  panel1.Controls.Remove(item);
                  break;
             }
         }
    }
