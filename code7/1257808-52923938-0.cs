    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace DataGridViewTest
    {
	internal class DataGridViewHtmlCell : DataGridViewTextBoxCell
	{
		protected override void Paint(
			Graphics graphics,
			Rectangle clipBounds,
			Rectangle cellBounds,
			Int32 rowIndex,
			DataGridViewElementStates cellState,
			Object values,
			Object formattedValue,
			String errorText,
			System.Windows.Forms.DataGridViewCellStyle cellStyle,
			DataGridViewAdvancedBorderStyle advancedBorderStyle,
			DataGridViewPaintParts paintParts)
		{
            // add a condition here to check formattedValue is Html
            // you shall use HtmlAgilityPack to determine this.
            if(isHtml)
            {
			    RenderHtmlValue(graphics, cellBounds, formattedValue, true);
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, values, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
		}	
		private Size RenderHtmlValue(
			Graphics graphics,
			Rectangle cellBounds,
			string formattedValue,
			bool drawCell)
		{
			using (var webBrowser = new WebBrowser())
			{
				webBrowser.ScrollBarsEnabled = false;
				webBrowser.Navigate("about:blank");
				webBrowser.Document.Write(formattedValue);
				webBrowser.Size = Size;
				var rect = new Rectangle(
					webBrowser.Document.Body.ScrollRectangle.Location,
					webBrowser.Document.Body.ScrollRectangle.Size);
				rect.Width = Size.Width - cellBounds.X;
				webBrowser.Size = rect.Size;
				cellBounds = new Rectangle(cellBounds.X, cellBounds.Y, rect.Width, rect.Height);
				var htmlBodyElement = webBrowser.Document.Body.DomElement as mshtml.IHTMLBodyElement;
				htmlBodyElement.WhenNotNull(
					bodyElement =>
					{
						cellBounds.Height += Convert.ToInt32(htmlBodyElement.bottomMargin);
					});
				if(drawCell)
				{
					using (var bitmap = new Bitmap(webBrowser.Width, webBrowser.Height))
					{
						webBrowser.DrawToBitmap(bitmap, targetBounds);
						graphics.DrawImage(bitmap, location);
					}
				}
			}
			return cellBounds.Size;
		}
		protected override Size GetPreferredSize(
			Graphics graphics,
			System.Windows.Forms.DataGridViewCellStyle cellStyle,
			Int32 rowIndex,
			Size constraintSize)
		{
			return RenderHtmlValue(graphics, cellBounds, formattedValue, false);
		}
	}
}
