        {
            Graphics g = e.Graphics;
            string tabText = tabControl1.TabPages[e.Index].Text;
            SizeF textSize = g.MeasureString(tabText, tabControl1.Font);
            Brush _textBrush = Brushes.Black;
            TabPage _tabPage = tabControl1.TabPages[e.Index];
            System.Drawing.Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);
            PointF rotPt = new PointF(_tabBounds.Left + (_tabBounds.Width / 2) - (textSize.Height / 2), _tabBounds.Top + (_tabBounds.Height / 2) + (textSize.Width/2));
            if (e.State.HasFlag(DrawItemState.Selected))
            {
                g.TranslateTransform(rotPt.X, rotPt.Y);
                g.RotateTransform(-90);
                g.TranslateTransform(-(rotPt.X), -(rotPt.Y));
                g.DrawString(tabText,
                    new Font(tabControl1.Font, FontStyle.Bold),
                    _textBrush,
                    new PointF(rotPt.X, rotPt.Y));
                g.ResetTransform();
            }
            else
            {
                g.TranslateTransform(rotPt.X, rotPt.Y);
                g.RotateTransform(-90);
                g.TranslateTransform(-rotPt.X, -rotPt.Y);
                
                g.DrawString(tabText,
                    tabControl1.Font,
                    _textBrush,
                    new PointF(rotPt.X,rotPt.Y));
                g.ResetTransform();
            }
        }
