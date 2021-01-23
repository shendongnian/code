    double minR = System.Convert.ToDouble(MinR.Value);
    double maxR = System.Convert.ToDouble(MaxR.Value);
    double minI = System.Convert.ToDouble(MaxI.Value);
    double maxI = System.Convert.ToDouble(MinI.Value);
    int maxN = System.Convert.ToInt32(Iterations.Value);
    
    SolidBrush MandelColor = new SolidBrush(Color.Red);
    
    using(var graphics = Renderer.CreateGraphics())
    {
      graphics.Clear(Color.White);
      for (int y = 0; y < Renderer.Height; y++)
      {
          for (int x = 0; x < Renderer.Width; x++)
          {
    
              double cr = fitInRRange(x, Renderer.Width, minR, maxR);
              double ci = fitInIRange(y, Renderer.Height, minI, maxI);
    
              int n = findMandelbrot(cr, ci, maxN);
    
              double t = ((n + 0.0) / (maxN + 0.0));
    
              MandelColor.Color = Color.FromArgb(System.Convert.ToInt32(9 * (1 - t) * t * t * t * 255), System.Convert.ToInt32(15 * (1 - t) * (1 - t) * t * t * 255), System.Convert.ToInt32(8.5 * (1 - t) * (1 - t) * (1 - t) * t * 255));
    
              gfx.FillRectangle(MandelColor, x, y, 1, 1);
    
          }
      }
    }
