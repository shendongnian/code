    public int DrawingPixelX(ExcelWorksheet worksheet, ExcelDrawing drawing)
	{
		const int emuPerPixel = ExcelDrawing.EMU_PER_PIXEL;
		decimal mdw = worksheet.Workbook.MaxFontWidth;
		var pix = 0;
		for (var i = 1; i <= drawing.From.Column; i++)
			pix += (int)decimal.Truncate(((256 * (decimal)worksheet.Column(i).Width + decimal.Truncate(128 / mdw)) / 256) * mdw);
		pix += drawing.From.ColumnOff / emuPerPixel;
		return pix;
	}
	public int DrawingPixelY(ExcelWorksheet worksheet, ExcelDrawing drawing)
	{
		const int emuPerPixel = ExcelDrawing.EMU_PER_PIXEL;
		var piy = 0;
		for (var i = 1; i <= drawing.From.Row; i++)
			piy += (int)(worksheet.Row(i).Height / 0.75);
		piy += drawing.From.RowOff / emuPerPixel;
		return piy;
	}
