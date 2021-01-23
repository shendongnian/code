    public void DrawFilledRectangle(uint x0, uint y0, int Width, int Height, int color)
		{
			for (uint i = 0; i < Width; i++)
			{
				for (uint h = 0; h < Height; h++)
				{
					setPixel((int)(x0 + i), (int)(y0 + h), color);
				}
			}
		}
