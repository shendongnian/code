      cmb.SelectionChanged += (o, e) =>
      {
        Grid rowGrid = new Grid();
        Grid storeRowGridInBig = new Grid();
        for (int i = 0; i < 4; i++)
          rowGrid.RowDefinitions.Add(new RowDefinition());
        for (int i = 0; i < 4; i++)
        {
          if (i == 0)
          {
            TextBlock txt1 = new TextBlock();
            txt1.Text = "for 1";
            rowGrid.Children.Add(txt1);
            Grid.SetRow(txt1, i);
          }
          else if (i == 1)
          {
            TextBlock txt1 = new TextBlock();
            txt1.Text = "for 2";
            rowGrid.Children.Add(txt1);
            Grid.SetRow(txt1, i);
          }
        }
        storeRowGridInBig.Children.Add(rowGrid);
        Grid.SetRow(storeRowGridInBig, 1);
        if (LayoutRoot.Children.Count > 1)
        {
          LayoutRoot.Children.RemoveAt(LayoutRoot.Children.Count - 1);
        }
        LayoutRoot.Children.Add(storeRowGridInBig);
      };
