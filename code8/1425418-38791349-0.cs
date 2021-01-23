        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null) return;
            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags = sf.FormatFlags | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.DisplayFormatControl;
            e.PaintBackground(e.CellBounds, true);
            SolidBrush br = new SolidBrush(Color.White);
            if (((int)e.State & (int)DataGridViewElementStates.Selected) == 0)
                br.Color = Color.Black;
            string text = e.Value.ToString();
            SizeF textSize = e.Graphics.MeasureString(text, Font, e.CellBounds.Width, sf);
            int keyPos = text.IndexOf(keyValue, StringComparison.OrdinalIgnoreCase);
            if (keyPos >= 0)
            {
                SizeF textMetricSize = new SizeF(0, 0);
                if (keyPos >= 1)
                {
                    string textMetric = text.Substring(0, keyPos);
                    textMetricSize = e.Graphics.MeasureString(textMetric, Font, e.CellBounds.Width, sf);
                }
                SizeF keySize = e.Graphics.MeasureString(text.Substring(keyPos, keyValue.Length), Font, e.CellBounds.Width, sf);
                float left = e.CellBounds.Left + (keyPos <= 0 ? 0 : textMetricSize.Width) + 2;
                RectangleF keyRect = new RectangleF(left, e.CellBounds.Top + 1, keySize.Width, e.CellBounds.Height - 2);
                var fillBrush = new SolidBrush(Color.Yellow);
                e.Graphics.FillRectangle(fillBrush, keyRect);
                fillBrush.Dispose();
            }
            e.Graphics.DrawString(text, Font, br, new PointF(e.CellBounds.Left + 2, e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2), sf);
            e.Handled = true;
            br.Dispose();
        }
