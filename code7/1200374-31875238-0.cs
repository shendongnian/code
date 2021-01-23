    for (int i = 0; i < 100; i++)
    {
      byte r = 0;
      byte g = 0;
      byte b = (byte)(255 - i);
      var color = System.Windows.Media.Color.FromRgb(r, g, b);
      var brush = new System.Windows.Media.SolidColorBrush(color);
      // Use brush here...
    }
