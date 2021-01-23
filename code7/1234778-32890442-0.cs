    Mycontrol m = new Mycontrol();
         RowDefinition rowDef1 = new RowDefinition();
        
                    rowDef1.MaxHeight = m.ExpandedSise;
                    rowDef1.MinHeight = m.Height;
                    rowDef1.Height = new GridLength(m.RowDefColapsedSize);
                    int rownumber = grid2.RowDefinitions.Count;
                    grid2.RowDefinitions.Insert(rownumber, rowDef1);
                    Grid.SetRow(m, rownumber);
                    m.counter.Content = Grid.GetRow(m).ToString();
                    grid2.Children.Add(m);
