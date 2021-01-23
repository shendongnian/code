    for (int i = 0; i < imgBitmap.Width; i++)
         {
         for (int j = 0; j < imgBitmap.Height; j++)
              {
              // map the angles from image coordinates
              double theta = Algebra.MapCoordinate(0.0, imgBitmap.Width - 1,
                  theta1, theta0, i);
              double phi = Algebra.MapCoordinate( 0.0, imgBitmap.Height - 1,phi0,
                  phi1, j);
              // find the cartesian coordinates
              double x = radius * Math.Sin(phi) * Math.Cos(theta);
              double y = radius * Math.Sin(phi) * Math.Sin(theta);
              double z = radius * Math.Cos(phi);
              // apply rotation around X and Y axis to reposition the sphere
              RotX(1.5, ref y, ref z);
              RotY(-2.5, ref x, ref z);
              // plot only positive points
              if (z > 0)
                   {
                   Color color = imgBitmap.GetPixel(i, j);
                   Brush brs = new SolidBrush(color);
                   int ix = (int)x + 100;
                   int iy = (int)y + 100;
                   graphics.FillRectangle(brs, ix, iy, 1, 1);
                   brs.Dispose();
                  }
              }
         }
