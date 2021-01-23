    private void dataGridView2_CellPainting(object sender, 
                                            DataGridViewCellPaintingEventArgs e)
    {
        //e.PaintBackground(e.CellBounds, true);
        //e.PaintContent(e.CellBounds);
        if (e.ColumnIndex == 4 && e.RowIndex == 0)  // use your own checks here!!
        {
            e.Graphics.Clear(Color.Wheat);
            e.PaintBackground(e.CellBounds, true);
            e.PaintContent(e.CellBounds);
            Graphics g = e.Graphics;
            Color c = Color.Empty;
            string s = "";
            Brush br = SystemBrushes.WindowText;
            Brush brBack;
            Rectangle rDraw;
            rDraw = e.CellBounds;
            rDraw.Inflate(-1, -1);
            {
                brBack = Brushes.White;
                g.FillRectangle(brBack, e.CellBounds);
            }
            try
            {    // use your own code here again!
                //  ComboboxColorItem oColorItem = 
                //      (ComboboxColorItem)((ComboBox)sender).SelectedItem;
                s = "WW";// oColorItem.ToString();
                c = Color.LawnGreen;// oColorItem.Value;
            } catch
            {
                s = "red";
                c = Color.Red;
            }
            int butSize = e.CellBounds.Height;
            Rectangle rbut = new Rectangle(e.CellBounds.Right - butSize , 
                                           e.CellBounds.Top, butSize , butSize );
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, rbut,  
                       System.Windows.Forms.VisualStyles.ComboBoxState.Normal);
            SolidBrush b = new SolidBrush(c);
            Rectangle r = new Rectangle( e.CellBounds.Left + 5, 
                                         e.CellBounds.Top + 3, 10, 10);
            g.FillRectangle(b, r);
            g.DrawRectangle(Pens.Black, r);
            g.DrawString(s, Form.DefaultFont, Brushes.Black, 
                         e.CellBounds.Left + 25, e.CellBounds.Top + 1);
            b.Dispose();
            //g.Dispose();  <-- do not dispose of thing you have not created!
            e.Handled = true;
        }
    }
