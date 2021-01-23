      for (int i = 0; i < textblocknames.Length; i++)
            {
                Border brd = new Border();
                brd.Name = string.Format("border_{0}", i);
                brd.BorderThickness = new Thickness(0, 0, 1, 1);
                brd.BorderBrush = Brushes.Black;
                object item = GridName.FindName(textblocknames[i]);
                brd.Child = item;
            }
