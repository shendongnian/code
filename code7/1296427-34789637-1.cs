    private void transmit_pic()
    {
        using(Bitmap b = new Bitmap(img))
        using(Bitmap bm = CopyBitmap(b))
		{
			int size_X = bm.Width;
			int size_Y = bm.Height;
		
			int px = 255;
			Color Green  = Color.FromArgb(0,255,0);
			for (int h = 0; h < size_Y; h++)
			{
				for (int w = 0; w < size_X; w++)
				{
					px = (int)bm.GetPixel(w, h).G;
					if (px < 128)
					{
					   // i shorted it a litel bit
					   if(somethig not imprtend here){
						bm.SetPixel(w, h, Green);
						img = (Image)CopyBitmap(bm);
					   }
					}
				}
			}
		}
        Console.Write("DONE");
    }
