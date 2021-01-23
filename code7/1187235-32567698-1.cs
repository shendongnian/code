      OpenXmlElement oldFill = stylesheet.Fills.FirstOrDefault(f => f.OuterXml.Contains("08F47B")); // find the fill that uses your unique color
      if (oldFill != null) // maybe you generate the .xlsx and the "gradient fill" is not always present
      {
        GradientFill gradientFill = new GradientFill() { Degree = 0 };
        gradientFill.Append(new GradientStop() { Position = 0D, Color = new Color() { Rgb = "FF00FF00" } });
        gradientFill.Append(new GradientStop() { Position = 1D, Color = new Color() { Rgb = "FFFFFFFF" } });
        oldFill.ReplaceChild(gradientFill, oldFill.FirstChild); // inside the fill replace the patternFill with your gradientFill
      }
      package.Close();
