            var progressColumn = this.DataGridView.Columns[this.ColumnIndex] as DataGridViewProgressColumn;
            if (percentage > 0.0 && progressColumn != null)
            {
                // Draw the progress bar and the text
                Brush fillColor;
                if (percentage < progressColumn.RedUntil)
                {
                    fillColor = new SolidBrush(Color.Red);
                }
                else if (percentage < progressColumn.YellowUntil)
                {
                    fillColor = new SolidBrush(Color.Yellow);
                }
                else
                {
                    fillColor = new SolidBrush(Color.Green);
                }
                g.FillRectangle(fillColor, cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + 6, cellBounds.Y + 2);
            }
            else
