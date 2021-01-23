      private static void setBorder( Border border, XlBorderWeight borderWeight )
      {
         border.LineStyle = XlLineStyle.xlContinuous;
         border.ColorIndex = XlConstants.xlAutomatic;
         border.TintAndShade = 0;
         border.Weight = borderWeight;
      }
