        private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40; //Change this to your desired item height
        }
    
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if (Object.ReferenceEquals(null, box))
                return;
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                using (Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                                      ? new SolidBrush(SystemColors.Highlight)
                                      : new SolidBrush(e.BackColor))
                {
                    using (Brush textBrush = new SolidBrush(e.ForeColor))
                    {
                        g.FillRectangle(brush, e.Bounds);
                        g.DrawString(box.Items[e.Index].ToString(),
                                     e.Font,
                                     textBrush,
                                     e.Bounds,
                                     StringFormat.GenericDefault);
                    }
                }
            }
            e.DrawFocusRectangle();
        }
