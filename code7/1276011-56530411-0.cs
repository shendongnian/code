     public Image _Image_v3_1_CustomMode(Image b1, float angle,float dx,float dy,float sx,float sy)
        
            {
                Bitmap bitmap = new Bitmap(b1.Width, b1.Height);
                
                using(Graphics ehack = Graphics.FromImage(bitmap))
                {
                    ehack.RotateTransform(angle);
                    ehack.TranslateTransform(dx, dy);
                    ehack.ScaleTransform(sx, sy);
                    ehack.DrawImage(b1, 0, 0);
                    
        
                    return bitmap;
                }
                
        
        }
