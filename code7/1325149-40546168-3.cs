	// clear the canvas / fill with white
	canvas.DrawColor (SKColors.White);
	// set up drawing tools
	using (var paint = new SKPaint ()) {
	  paint.TextSize = 64.0f;
	  paint.IsAntialias = true;
	  paint.Color = new SKColor (0x42, 0x81, 0xA4);
	  paint.IsStroke = false;
	  // draw the text
	  canvas.DrawText ("Skia", 0.0f, 64.0f, paint);
	}
