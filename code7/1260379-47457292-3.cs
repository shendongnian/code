    private void InitContinents(Bitmap map, Int32 nearPixelLimit)
    {
        // Build hues map from colour palette. Since detection is done
        // by hue value, any grey or white values on the image will be ignored.
        // This does mean the process only works with actual colours.
        // In this function it is assumed that index 0 is the white background.
        Double[] hueMap = new Double[this.continentsPal.Length];
        for (Int32 i = 0; i < this.continentsPal.Length; i++)
        {
            Color col = this.pal[i];
            if (col.GetSaturation() < .25)
                hueMap[i] = -2;
            else
                hueMap[i] = col.GetHue();
        }
        Int32 w = map.Width;
        Int32 h = map.Height;
        Bitmap newMap = ImageUtils.PaintOn32bpp(map, continentsPal[0]);
        // BUILD REDUCED COLOR MAP
        Byte[] guideMap = new Byte[w * h];
        Int32 stride;
        Byte[] imageData = ImageUtils.GetImageData(newMap, out stride);
        for (Int32 y = 0; y < h; y++)
        {
            Int32 sourceOffs = y * stride;
            Int32 targetOffs = y * w;
            for (Int32 x = 0; x < w; x++)
            {
                Color c = Color.FromArgb(255, imageData[sourceOffs + 2], imageData[sourceOffs + 1], imageData[sourceOffs + 0]);
                Double hue;
                // Detecting on hue. Values with < 25% saturation are ignored.
                if (c.GetSaturation() < .25)
                    hue = -2;
                else
                    hue = c.GetHue();
                // Get the closest match
                Double smallestHueDiff = Int32.MaxValue;
                Int32 smallestHueIndex = -1;
                for (Int32 i = 0; i < hueMap.Length; i++)
                {
                    Double hueDiff = Math.Abs(hueMap[i] - hue);
                    if (hueDiff < smallestHueDiff)
                    {
                        smallestHueDiff = hueDiff;
                        smallestHueIndex = i;
                    }
                }
                guideMap[targetOffs] = (Byte)(smallestHueIndex < 0 ? 0 : smallestHueIndex);
                // Increase read pointer with 4 bytes for next pixel
                sourceOffs += 4;
                // Increase write pointer with 1 byte for next index
                targetOffs++;
            }
        }
        // Remove random edge pixels, and save in global var.
        this.continentGuide = RefineMap(guideMap, w, h, nearPixelLimit);
        // Build image from the guide map.
        this.overlay = ImageUtils.BuildImage(this.continentGuide, w, h, w, PixelFormat.Format8bppIndexed, this.continentsPal, null);
    }
