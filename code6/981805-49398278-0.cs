    using (var ms = new MemoryStream((byte[])(bits)))
            {
                var emf = new Metafile(ms);
                var scale = 400 / emf.HorizontalResolution;
                var Width= emf.Width * scale;
                var Height = emf.Height * scale;
                System.Drawing.Bitmap b = new System.Drawing.Bitmap((Int32)Width, (Int32)Height);
                var G = System.Drawing.Graphics.FromImage(b);
                G.Clear(System.Drawing.Color.White);
                G.DrawImage(emf, 0, 0, (float)Width, (float)Height);
                b.Save(pngTarget, System.Drawing.Imaging.ImageFormat.Png);
            }
