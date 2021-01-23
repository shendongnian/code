    private static IEnumerable<System.Drawing.Point> GetTransparencyPoints(System.Drawing.Bitmap image) 
    {
      for (int i = 0 ; i < image.Width ; i ++ ) {
        for (int j  = 0 ; j < image.Height ; j ++) { 
    
             Color color = image.GetPixel(i, j) ; 
    
             if (color == Color.Transparent) { 
                yield return new System.Drawing.Point(i, j) ; 
             }
        }
      } 
    
    }
