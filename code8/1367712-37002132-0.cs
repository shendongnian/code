      TextBox txt1 = null;
          
      //Lookup txt1
      foreach (Control item in panel1.Controls)
      {
        if (item.Name == "testText")
        {
          txt1 = (TextBox)item;
        }
      }      
      
      TextBox txt2 = null;
      //Lookup txt2
      foreach (Control item in panel1.Controls)
      {
        if (item.Name == "testText2")
        {
          txt2 = (TextBox)item;
        }
      }
      if (Cat0.Text == "test")
      {
        if (txt1 == null)
        {
          //only if txt1 not found add it
          txt1 = new TextBox();
          txt1.Name = "testText";
          txt1.Width = 170;
          txt1.Height = 21;
          txt1.Location = new System.Drawing.Point(122, 145);
          panel1.Controls.Add(txt1);
        }
    
        if (txt2 == null)
        {
          txt2 = new TextBox();
          txt2.Name = "testText2";
          txt2.Width = 170;
          txt2.Height = 21;
          txt2.Location = new System.Drawing.Point(122, 171);
          panel1.Controls.Add(txt2);
        }
      }
      else
      {
        if (panel1.Controls.Contains(txt1)) // not working
        {
          panel1.Controls.Remove(txt1);
        }
      }
    }
