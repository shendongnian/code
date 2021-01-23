    if (height <= 800)
	{
		int printHeight = height;
		printHeight += 75;
		e.Graphics.DrawString(checkedRow.Cells[1].FormattedValue.ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(this.dataGridView1.ForeColor), new Point(60, printHeight));
		Bitmap bmp = Properties.Resources.ugro;
		Image newImage = bmp;
		e.Graphics.DrawImage(newImage, 20, printHeight + 20, 100, 100);
		e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), 10, printHeight - 20, 300, 150);
		printHeight += 75;
		e.Graphics.DrawString(checkedRow.Cells[2].FormattedValue.ToString(), new Font("Code_39 3_0", 36), new SolidBrush(this.dataGridView1.ForeColor), new Point(  150, printHeight));
	}
	if (height > 800)
	{
		Bitmap bmp = Properties.Resources.ugro;
		Image newImage = bmp;
		int width = 400;
		height1 += 75;
		e.Graphics.DrawString(checkedRow.Cells[1].FormattedValue.ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(this.dataGridView1.ForeColor), new Point(width + 60, height1));
		e.Graphics.DrawImage(newImage, width + 20, height1 + 20, 100, 100);
		e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), width + 10, height1 - 20, 300, 150);
		height1 += 75;
		e.Graphics.DrawString(checkedRow.Cells[2].FormattedValue.ToString(), new Font("Code_39 3_0", 36), new SolidBrush(this.dataGridView1.ForeColor), new Point(width + 150, height1));
	}
