        private static D.Size pixelsToEmus(int widthPx, int heightPx, double resDpiX, double resDpiY, int zoomX, int zoomY)
        {
            const int emusPerInch = 914400;
            const int emusPerCm = 360000;
            const decimal maxWidthCm = 16.51m;
            var widthEmus = (int)(widthPx / resDpiX * emusPerInch) * zoomX / 100;
            var heightEmus = (int)(heightPx / resDpiY * emusPerInch) * zoomY / 100;
            var maxWidthEmus = (int)(maxWidthCm * emusPerCm);
            if (widthEmus > maxWidthEmus)
            {
                var ratio = ((decimal)heightEmus / (decimal)widthEmus);
                widthEmus = maxWidthEmus;
                heightEmus = (int)(widthEmus * ratio);
            }
            return new D.Size(widthEmus, heightEmus);
        }
        public static D.Size GetTextSize(this CWatermarkItemBase watermark, string runText)
        {
            var fs = watermark.GetFontStyle();
            var sz = watermark.FontSize;
            var proposedSize = new D.Size(int.MaxValue, int.MaxValue);
            D.Size sf;
            using (var ff = new D.FontFamily(watermark.FontFamily))
            {
                try
                {
                    using (var f = new D.Font(ff, (float)sz, fs))
                    {
                        const TextFormatFlags tff = TextFormatFlags.NoPadding;
                        sf = TextRenderer.MeasureText(runText, f, proposedSize, tff);
                    }
                }
                catch (ArgumentException)
                {
                    try
                    {
                        const D.FontStyle fs2 = D.FontStyle.Regular;
                        using (D.Font f = new D.Font(ff, (float)sz, fs2))
                        {
                            const TextFormatFlags tff = TextFormatFlags.NoPadding;
                            sf = TextRenderer.MeasureText(runText, f, proposedSize, tff);
                        }
                    }
                    catch (ArgumentException)
                    {
                        const D.FontStyle fs2 = D.FontStyle.Bold;
                        try
                        {
                            using (var f = new D.Font(ff, (float)sz, fs2))
                            {
                                const TextFormatFlags tff = TextFormatFlags.NoPadding;
                                sf = TextRenderer.MeasureText(runText, f, proposedSize, tff);
                            }
                        }
                        catch (ArgumentException)
                        {
                            // if both regular and bold fail, then get metrics for Times New Roman
                            // use the original FontStyle (in fs)
                            using (var ff2 = new D.FontFamily("Times New Roman"))
                            using (var f = new D.Font(ff2, (float)sz, fs))
                            {
                                const TextFormatFlags tff = TextFormatFlags.NoPadding;
                                sf = TextRenderer.MeasureText(runText, f, proposedSize, tff);
                            }
                        }
                    }
                }
            }
            D.Size s2 = pixelsToEmus(sf.Width, sf.Height, 96, 96, 100, 100);
            return s2;
        }
        public static D.Size GetImageSize(this CWatermarkItemImage watermarkItem)
        {
            var img = new BitmapImage(new Uri(watermarkItem.FilePath, UriKind.RelativeOrAbsolute));
            return pixelsToEmus(img.PixelWidth, img.PixelHeight, img.DpiX, img.DpiY, watermarkItem.ZoomWidth, watermarkItem.ZoomHeight);
        }
