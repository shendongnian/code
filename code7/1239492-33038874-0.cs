    set
	{
		if ( value != _size )
		{
			Remake( _scaledSize / _size * value, _size, ref _scaledSize,
						ref _font );
			_size = value;
		}
	}
	//...
	
	/// <summary>
	/// Recreate the font based on a new scaled size.  The font
	/// will only be recreated if the scaled size has changed by
	/// at least 0.1 points.
	/// </summary>
	/// <param name="scaleFactor">
	/// The scaling factor to be used for rendering objects.  This is calculated and
	/// passed down by the parent <see cref="GraphPane"/> object using the
	/// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
	/// font sizes, etc. according to the actual size of the graph.
	/// </param>
	/// <param name="size">The unscaled size of the font, in points</param>
	/// <param name="scaledSize">The scaled size of the font, in points</param>
	/// <param name="font">A reference to the <see cref="Font"/> object</param>
	private void Remake( float scaleFactor, float size, ref float scaledSize, ref Font font )
	{
		float newSize = size * scaleFactor;
		float oldSize = ( font == null ) ? 0.0f : font.Size;
		// Regenerate the font only if the size has changed significantly
		if ( font == null ||
				Math.Abs( newSize - oldSize ) > 0.1 ||
				font.Name != this.Family ||
				font.Bold != _isBold ||
				font.Italic != _isItalic ||
				font.Underline != _isUnderline )
		{
			FontStyle style = FontStyle.Regular;
			style = ( _isBold ? FontStyle.Bold : style ) |
						( _isItalic ? FontStyle.Italic : style ) |
						 ( _isUnderline ? FontStyle.Underline : style );
			scaledSize = size * (float)scaleFactor;
			font = new Font( _family, scaledSize, style, GraphicsUnit.World );
		}
	}
