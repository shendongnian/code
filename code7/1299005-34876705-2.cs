    private void gvView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
          if (e.Column != null && e.Column.Name == bgcStav.Name)
          {
            float minFontSize = 6;
            string text = "teeeeeeeeeeeeeext";
            int minWidth = gvView.CalcColumnBestWidth(bgcStav);        
            SizeF s = e.Appearance.CalcTextSize(e.Graphics, text, minWidth);
            if (s.Width >= minWidth)
            {
              e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, minFontSize);          
            }
          }
        }
