	private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
	{
		if (e.Index > -1)
		{
			string item = listBox1.Items[e.Index].ToString();
			if (item != null)
			{
				var brush = GetMessageBrush(item);
				e.Graphics.DrawString(item, e.Font, brush, e.Bounds.X, e.Bounds.Y, StringFormat.GenericDefault);
			}
			e.DrawFocusRectangle();
		}
	}
