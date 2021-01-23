     private void gvView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
          if (e.Column != null && e.Column.Name == bgcStav.Name)
          {
            string text = e.DisplayText;
            string newText = "";
            int maxWidth = e.Bounds.Width - 20;
            SizeF textSize =e.Graphics.MeasureString(text, e.Appearance.Font);
            if (textSize.Width >= maxWidth)
            {
              string textPom = "";
              for (int i = 0; i < text.Length; i++)
              {
                textPom = text.Substring(0, i) + "...";
                textSize = e.Graphics.MeasureString(textPom, e.Appearance.Font);
                if (textSize.Width >= maxWidth)
                {
                  newText = text.Substring(0, i - 1) + "...";
                  break;
                }
              }
              e.DisplayText = newText;
            }           
          }
        }
