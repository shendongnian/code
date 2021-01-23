      var left = 0;
      var top = 0;
      var btnWith = 20;
      var btnHeigh = 50;
      int x = 2, y = 3;
      for (var i = 0; i < x; i++)
      {
        for (var j = 0; j < y; j++)
        {
          var btn = new Button();
          btn.Name = j + "t" + i;
          btn.Text = j + "ff" + i;
          btn.Height = btnHeigh ;
          btn.Width = btnWith;
          btn.Location = new Point(left, top);
          left += btnWith;
          Controls.Add(btn);
        }
        top += btnHeigh;
      }
